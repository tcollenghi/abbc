using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ProjetoBase.DAO;
using ProjetoBase.DTO;
using ProjetoBase.Helpers.Exceptions;
using ProjetoBase.Models;
using ProjetoBase.Service;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.DirectoryServices;
using System.Configuration;
using System.Data.Entity;

namespace ProjetoBase.Helpers
{
    public class SessionHelper
    {
        #region Usuario Logado
        /// <summary>
        /// Armazena o usuário logado na aplicação
        /// </summary>
        public static Usuario UsuarioLogado
        {
            get
            {
                Usuario user = null;
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    user = (Usuario)HttpContext.Current.Session["Usuario"];

                    //Se o usuário não estiver attached no dao, então ele attacha
                    if (getProjetoBaseContext().Entry(user).State == EntityState.Detached)
                    {
                        getProjetoBaseContext().Usuario.Attach(user);
                    }
                }
                else
                {
                    //Se não for possível recuperar o usuário da sessão,
                    //Recupera o usuário do cookie, 
                    //e depois resgata do banco o usuário e salva na sessão
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        string nomeUsuario = HttpContext.Current.User.Identity.Name;

                        user = AutenticacaoService.RecuperaUsuario(nomeUsuario);
                        UsuarioLogado = user;
                    }
                    //Tenta pegar o usuário do windows
                    //Se conseguir tenta resgatar do banco o usuário do windows.
                    var winUser = HttpContext.Current.Request.LogonUserIdentity.Name;
                    if (user == null && winUser != null && winUser != "" && winUser.Contains("SOLLOBRASIL"))
                    {
                        winUser = winUser.Substring(winUser.LastIndexOf('\\') + 1);
                        var nomeUsuario = winUser;
                        user = AutenticacaoService.RecuperaUsuario(winUser);
                        UsuarioLogado = user;
                    }
                }
                return user;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
                if (value == null)
                {
                    FormsAuthentication.SetAuthCookie(null, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(value.login, true);
                }
            }
        }

        /// <summary>
        /// Finaliza a session do usuário logado.
        /// </summary>
        public static void abandonarSession()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SetAuthCookie(null, true);
        }
        #endregion

        #region Mensagens do Toastr
        /// <summary>
        /// Lista de mensagens pendentes a serem exibidas
        /// </summary>
        public static List<MensagemDTO> MensagensToView = new List<MensagemDTO>();

        /// <summary>
        /// Método que adiciona uma mensagem para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        public static void AddMensagemToView(string mensagemPrimaria)
        {
            MensagensToView.Add(new MensagemDTO(mensagemPrimaria));
        }
        /// <summary>
        /// Método que adiciona uma mensagem para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        /// <param name="mensagemSecundaria"></param>
        public static void AddMensagemToView(string mensagemPrimaria, string mensagemSecundaria)
        {
            MensagensToView.Add(new MensagemDTO(mensagemPrimaria, mensagemSecundaria));
        }
        /// <summary>
        /// Método que adiciona uma mensagem para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        /// <param name="tipo"></param>
        public static void AddMensagemToView(string mensagemPrimaria, MensagemDTO.EnumTipoMensagem tipo)
        {
            MensagensToView.Add(new MensagemDTO(mensagemPrimaria, tipo));
        }
        /// <summary>
        /// Método que adiciona uma mensagem para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        /// <param name="mensagemSecundaria"></param>
        /// <param name="tipo"></param>
        public static void AddMensagemToView(string mensagemPrimaria, string mensagemSecundaria, MensagemDTO.EnumTipoMensagem tipo)
        {
            MensagensToView.Add(new MensagemDTO(mensagemPrimaria, mensagemSecundaria, tipo));
        }

        /// <summary>
        /// Retorna a lista de mensagens armazenadas e apaga da lista de pendentes.
        /// </summary>
        /// <returns></returns>
        public static List<MensagemDTO> getAndEraseMensagensToView()
        {
            List<MensagemDTO> mensagens = MensagensToView;
            MensagensToView = new List<MensagemDTO>();
            return mensagens;
        }

        #endregion

        #region Util
        /// <summary>
        /// Verifica se a aplicação está rodando em ambiente de desenvolvimento.
        /// </summary>
        /// <returns></returns>
        public static bool isAmbienteDesenvolvimento()
        {
            return bool.Parse(ConfigurationManager.AppSettings["desenvolvimento"]);
        }
        #endregion

        #region Contexto do Entity Framework
        /// <summary>
        /// Retorna o contexto do entity framework, trabalhando com um context por request
        /// </summary>
        /// <returns></returns>
        public static ProjetoBaseContext getProjetoBaseContext()
        {
            if (HttpContext.Current.Session["ProjetoBaseContext"] == null)
            {
                var db = new ProjetoBaseContext();
                HttpContext.Current.Session["ProjetoBaseContext"] = db;
            }
            return (ProjetoBaseContext)HttpContext.Current.Session["ProjetoBaseContext"];
        }

        /// <summary>
        /// Destroi o contexto do Entity FrameWork, essa funcao é chamada no fim da request
        /// </summary>
        public static void destroyProjetoBaseContext()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["ProjetoBaseContext"] != null)
            {
                var db = (ProjetoBaseContext)HttpContext.Current.Session["ProjetoBaseContext"];
                HttpContext.Current.Session["ProjetoBaseContext"] = null;
                //Remove todas as modificações não salvas
                foreach (var entry in db.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                db.Dispose();
            }
        }
        #endregion

    }
}
