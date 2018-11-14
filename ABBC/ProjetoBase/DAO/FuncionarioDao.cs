using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class FuncionarioDao : BaseDao<Funcionario>
    {
        public static int countAtivos()
        {
            return Set.Count(x => x.Ativo);
        }

        public static List<Funcionario> FindAllAtivos()
        {
            return Set.Where(x => x.Ativo).ToList();
        }

        public static Funcionario FindByCpf(string cpf)
        {
            var user = Set.SingleOrDefault(x => x.CPF == cpf);
            //Testa se é case sensitive
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public static Funcionario FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public static Funcionario FindAllByIDFuncionario(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }

        public static List<Funcionario> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

    }
}