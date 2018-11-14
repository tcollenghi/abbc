using System;
using System.Collections.Generic;
using ProjetoBase.Models;

namespace ProjetoBase.DTO
{
    public class FuncionarioDTO
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public int NivelAcessso { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

        public FuncionarioDTO() { }

        public FuncionarioDTO(Funcionario funcionario)
        {
            ID = funcionario.ID;
            Nome = funcionario.Nome;
            Nascimento = funcionario.Nascimento;
            CPF = funcionario.CPF;
            RG = funcionario.RG;
            NivelAcessso = funcionario.NivelAcessso;
            Ativo = funcionario.Ativo;
            DataAlteracao = funcionario.DataAlteracao;

        }

        public Funcionario ParseToFuncionario()
        {
            Funcionario funcionario = new Funcionario()
            {
                Nome = Nome,
                Nascimento = Nascimento,
                CPF = CPF,
                RG = RG,
                NivelAcessso = NivelAcessso,
                Ativo = Ativo,
                DataAlteracao = DataAlteracao,
                ID = ID

            };

            return funcionario;
        }

        public Funcionario ParseToFuncionario(Funcionario funcionario)
        {
            funcionario.Nome = Nome;
            funcionario.Nascimento = Nascimento;
            funcionario.CPF = CPF;
            funcionario.RG = RG;
            funcionario.NivelAcessso = NivelAcessso;
            funcionario.Ativo = Ativo;
            funcionario.DataAlteracao = DataAlteracao;

            return funcionario;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do aluno não pode ser vazio.");
            }
            if (CPF == null || CPF.Length < 11 || CPF.Length > 12)
            {
                erros.Add("O CPF está incorreto.");
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();

            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do aluno não pode ser vazio.");
            }
            if (CPF == null || CPF.Length < 11 || CPF.Length > 12)
            {
                erros.Add("O CPF está incorreto.");
            }
            return erros;
        }
        
    }
}