using System;
using System.Collections.Generic;
using ProjetoBase.Models;
using ProjetoBase.Service;

namespace ProjetoBase.DTO
{
    public class CursoDTO
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string CargaHoraria { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public CursoDTO() { }

        public CursoDTO(Curso curso)
        {
            ID = curso.ID;
            Nome = curso.Nome;
            CargaHoraria = curso.CargaHoraria;
            DataAlteracao = curso.DataAlteracao;
            Ativo = curso.Ativo;
        }

        public Curso ParseToCurso()
        {
            Curso curso = new Curso()
            {
                Nome = Nome,
                Ativo = Ativo,
                CargaHoraria = CargaHoraria,
                DataAlteracao = DataAlteracao,
                ID = ID

            };

            return curso;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do curso não pode ser vazio.");
            }
            if (CargaHoraria == null || CargaHoraria == "")
            {
                erros.Add("Carga Horaria do curso não pode ser vazio.");
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do curso não pode ser vazio.");
            }
            if (CargaHoraria == null || CargaHoraria == "")
            {
                erros.Add("Carga Horaria do curso não pode ser vazio.");
            }

            return erros;
        }

        public Curso ParseToCurso(Curso curso)
        {
            curso.Nome = Nome;
            curso.CargaHoraria = CargaHoraria;
            curso.DataAlteracao = DataAlteracao;
            curso.Ativo = Ativo;
           
            return curso;
        }

    }
}