using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class CursoDao : BaseDao<Curso>
    {
        public static int countAtivos()
        {
            return Set.Count(x => x.Ativo);
        }

        public static List<Curso> FindAllAtivos()
        {
            return Set.Where(x => x.Ativo).ToList();
        }

        public static Curso FindByName(string nome)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public static List<Curso> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

        public static int FindAllByIDsCount(long ids)
        {
            return Set.Count(x => x.ID == ids);
        }

        public static Curso FindAllByIDCurso(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }

    }
}