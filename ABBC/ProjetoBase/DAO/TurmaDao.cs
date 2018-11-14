using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class TurmaDao : BaseDao<Turma>
    {
        public static int countAtivos()
        {
            return Set.Count(x => x.Ativo);
        }

        public static List<Turma> FindAllAtivos()
        {
            return Set.Where(x => x.Ativo).ToList();
        }

        public static Turma FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }


        public static List<Turma> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

        public static int FindAllByIDsCount(long ids)
        {
            return Set.Count(x => x.ID == ids);
        }

        public static Turma FindAllByIDTurma(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }
    }
}