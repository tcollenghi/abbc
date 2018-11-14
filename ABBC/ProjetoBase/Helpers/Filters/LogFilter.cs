using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.Models;
using ProjetoBase.DAO;

namespace ProjetoBase.Helpers.Filters
{
    [ExceptionFilter]
    public class LogFilter : ActionFilterAttribute, IActionFilter
    {
        public bool noLog = false;

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            Usuario usuarioLogado = SessionHelper.UsuarioLogado;

            //Se nenhum usuário está conectado então sai não guarda log
            if (usuarioLogado == null || noLog)
            {
                return;
            }

            string descricao = "";
            descricao += getBetterDescriptionAsPossible(filterContext);

            if (descricao.Length > 1000)
            {
                descricao = descricao.Substring(0, 1000) + "...";
            }
            var nomeUsuario = usuarioLogado.login;
            
            Log log = new Log
            {
                nomeUsuario = nomeUsuario,
                menu = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                opcao = filterContext.ActionDescriptor.ActionName,
                acao = descricao,
                method = filterContext.HttpContext.Request.HttpMethod,
                data = filterContext.HttpContext.Timestamp,
            };
            LogDao.Save(log);
        }

        private string getBetterDescriptionAsPossible(ActionExecutingContext filterContext)
        {
            string descricao = "";
            foreach (var par in filterContext.ActionParameters)
            {
                if (par.Value != null
                        && (par.Value.GetType() == typeof(string)
                        || par.Value.GetType() == typeof(long)
                        || par.Value.GetType() == typeof(int)
                        || par.Value.GetType() == typeof(bool)
                        || par.Value.GetType() == typeof(Boolean)
                        || par.Value.GetType() == typeof(String)
                        || par.Value.GetType() == typeof(double)))
                {
                    descricao += par.Key + ": " + par.Value + ", ";
                }
                else if (par.Value != null && (par.Value.GetType().FullName.Contains("DTO") 
                                || par.Value.GetType().FullName.Contains("Model")))
                {
                    var properties = par.Value.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        try
                        {
                            if (prop.GetValue(par.Value,null) != null)
                            {
                                var valor = prop.GetValue(par.Value,null).ToString();
                                if (valor.Length > 100)
                                {
                                    valor = valor.Substring(0, 100);
                                }
                                descricao += par.Key + "." + prop.Name + ": " + valor + ", ";
                            }
                        }
                        catch(Exception)
                        {

                        }
                    }
                }
            }
            return descricao;
        }

    }
}
