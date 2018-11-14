using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class PlanoPagamentoDao : BaseDao<PlanoPagamento>
    {
        public static List<PlanoPagamento> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

        public static int countAtivos()
        {
            return Set.Count(x => x.Ativo);
        }

        public static List<PlanoPagamento> FindAllAtivos()
        {
            return Set.Where(x => x.Ativo).ToList();
        }

        public static PlanoPagamento FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public static PlanoPagamento FindAllByIDPlanoPagamento(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }
    }
}