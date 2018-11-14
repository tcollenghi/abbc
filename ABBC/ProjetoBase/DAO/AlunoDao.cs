using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class AlunoDao : BaseDao<Aluno>
    {
        public static int countAtivos()
        {
            return Set.Count(x => x.Ativo);
        }

        public static List<Aluno> FindAllAtivos()
        {
            return Set.Where(x => x.Ativo).ToList();
        }

        public static Aluno FindByCpf(string cpf)
        {
            var user = Set.SingleOrDefault(x => x.Cpf == cpf);
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

        public static Aluno FindByName(string nomeAluno)
        {
            return Set.SingleOrDefault(x => x.Nome.ToLower() == nomeAluno.ToLower());
        }

        public static Aluno FindByEmail(string email)
        {
            return Set.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public static Aluno FindAllByIDAluno(long id)
        {
            return Set.SingleOrDefault(x => x.ID == id);
        }

        public static List<Aluno> FindAllByIDs(long ids)
        {
            return Set.Where(x => x.ID == ids).ToList();
        }

        public static List<string> validate(int curso, int turma)
        {
            List<string> erros = new List<string>();
            if (curso == 0)
            {
                erros.Add("Curso do aluno não pode ser vazio.");
            }
            if (turma == 0)
            {
                erros.Add("Turma do aluno não pode ser vazio.");
            }

            return erros;
        }
    }
}