using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class UsuarioDao : BaseDao<Usuario>
    {

        public static int countAtivos()
        {
            return Set.Count(x => x.ativo);
        }

        public static List<Usuario> FindAllAtivos()
        {
            return Set.Where(x => x.ativo).ToList();
        }

        public static Usuario FindByLogin(string login, string senha)
        {
            var user = Set.SingleOrDefault(x => x.login == login && x.senha == senha);
            //Testa se é case sensitive
            if (user != null && senha == user.senha)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public static Usuario FindByLogin(string nomeUsuario)
        {
            return Set.SingleOrDefault(x => x.login == nomeUsuario);
        }

        public static Usuario FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.nome == nome);
        }

        public static int countByName(string nome)
        {
            return Set.Count(x => x.nome == nome);
        }

        public static Usuario FindByEmail(string email)
        {
            return Set.SingleOrDefault(x => x.email.ToLower() == email.ToLower());
        }
        
    }
}