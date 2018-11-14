using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ProjetoBase.DTO;
using ProjetoBase.DAO;
using ProjetoBase.Helpers;
using ProjetoBase.Helpers.Filters;
using ProjetoBase.Models;

namespace ProjetoBase.Service
{
    public class AutenticacaoService
    {
        /// <summary>
        /// Autentica um usuário através do login e senha. 
        /// Se é a primeira vez que acessa a aplicação então é criado um perfil para o usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        internal static bool login(UsuarioSimplesDTO login)
        {
            var autenticado = true;
            //Verifica e recupera se é um usuário já registrado na da aplicação
            var user = UsuarioDao.FindByLogin(login.login, login.senha);
            if (user != null)
            {
                SessionHelper.UsuarioLogado = user;
                return autenticado;
            }
            autenticado = false;
            return autenticado;
        }

        /// <summary>
        /// Recupera o usuário já registrado na aplicação através do login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Usuario RecuperaUsuario(string user)
        {
            return UsuarioDao.FindByLogin(user);
        }


        /// <summary>
        /// Lista todos os usuário, tanto já registrados na aplicação, quanto ainda não registrados
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioSimplesDTO> listarTodosUsuarios()
        {
            List<UsuarioSimplesDTO> usuariosDTO = new List<UsuarioSimplesDTO>();
            var usuariosSistema = UsuarioDao.FindAll();
            foreach (var user in usuariosSistema)
            {
                UsuarioSimplesDTO repetido = usuariosDTO.SingleOrDefault(x => x.login == user.login);
                if (repetido != null)
                {
                    usuariosDTO.Remove(repetido);
                }
                usuariosDTO.Add(new UsuarioSimplesDTO(user));
            }
            return usuariosDTO;
        }

        /// <summary>
        /// Verifica se existe um usuário já um determinado login (seja do vetorRH ou da aplicação)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool ExisteUsuarioComLogin(string login)
        {
            var existe = false;
            if (UsuarioDao.FindByLogin(login) != null)
            {
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// Verifica se existe um aluno com o mesmo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ExisteAlunoComCPF(string cpf)
        {
            var existe = false;
            if (AlunoDao.FindByCpf(cpf) != null)
            {
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// Verifica se existe um usuário com um determinado email (aplicação)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ExisteUsuarioComEmail(string email)
        {
            return UsuarioDao.FindByEmail(email) != null;
        }
        /// <summary>
        /// Verifica se existe um aluno com um determinado email (aplicação)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ExisteAlunoComEmail(string email)
        {
            return AlunoDao.FindByEmail(email) != null;
        }

    }
}