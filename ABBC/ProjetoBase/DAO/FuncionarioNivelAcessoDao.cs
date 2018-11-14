using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class FuncionarioNivelAcessoDao : BaseDao<FuncionarioNivelAcesso>
    {
        public static FuncionarioNivelAcesso FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public static FuncionarioNivelAcesso FindById(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }

        public static List<FuncionarioNivelAcesso> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

        public static int countByIdNivel(long ids)
        {
            return Set.Count(x => x.ID == ids);
        }
    }
}