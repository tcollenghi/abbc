using System;
using System.Collections.Generic;
using ProjetoBase.Models;
using ProjetoBase.Service;

namespace ProjetoBase.DTO
{
    public class TurmaDTO
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public TurmaDTO() { }

        public TurmaDTO(Turma turma)
        {
            ID = turma.ID;
            Nome = turma.Nome;
            DataAlteracao = turma.DataAlteracao;
            Ativo = turma.Ativo;
        }

        public Turma ParseToTurma()
        {
            Turma turma = new Turma()
            {
                Nome = Nome,
                Ativo = Ativo,
                DataAlteracao = DataAlteracao,
                ID = ID

            };

            return turma;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do Turma não pode ser vazio.");
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do Turma não pode ser vazio.");
            }

            return erros;
        }

        public Turma ParseToTurma(Turma turma)
        {
            turma.Nome = Nome;
            turma.DataAlteracao = DataAlteracao;
            turma.Ativo = Ativo;

            return turma;
        }

    }
}