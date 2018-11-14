using System;
using System.Collections.Generic;
using ProjetoBase.Models;
using ProjetoBase.Service;

namespace ProjetoBase.DTO
{
    public class PlanoPagamentoDTO
    {
        public long ID { get; set; }
     
        public string Nome { get; set; }
     
        public int NumeroParcelas { get; set; }
     
        public string Periodicidade { get; set; }
     
        public DateTime DataPrimeiraParcela { get; set; }
       
        public string Desconto { get; set; }
   
        public string Juros { get; set; }
     
        public string Multa { get; set; }
      
        public DateTime DataAlteracao { get; set; }
       
        public string UsuarioAlteracao { get; set; }
     
        public bool Ativo { get; set; }

        public PlanoPagamentoDTO() { }

        public PlanoPagamentoDTO(PlanoPagamento planoPagamento)
        {
            ID = planoPagamento.ID;
            Nome = planoPagamento.Nome;
            NumeroParcelas = planoPagamento.NumeroParcelas;
            Periodicidade = planoPagamento.Periodicidade;
            DataPrimeiraParcela = planoPagamento.DataPrimeiraParcela;
            Desconto = planoPagamento.Desconto;
            Juros = planoPagamento.Juros;
            Multa = planoPagamento.Multa;
            DataAlteracao = planoPagamento.DataAlteracao;
            UsuarioAlteracao = planoPagamento.UsuarioAlteracao;
            Ativo = planoPagamento.Ativo;
        }

        public PlanoPagamento ParseToPlanoPagamento()
        {
            PlanoPagamento planoPagamento = new PlanoPagamento()
            {
                Nome = Nome,
                NumeroParcelas = NumeroParcelas,
                Periodicidade = Periodicidade,
                DataPrimeiraParcela = DataPrimeiraParcela,
                Desconto = Desconto,
                Juros = Juros,
                Multa = Multa,
                DataAlteracao = DataAlteracao,
                UsuarioAlteracao = UsuarioAlteracao,
                Ativo = Ativo,
                ID = ID

            };

            return planoPagamento;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do Plano de Pagamento não pode ser vazio.");
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();
            if (Nome == null || Nome == "")
            {
                erros.Add("Nome do Plano de Pagamento não pode ser vazio.");
            }

            return erros;
        }

        public PlanoPagamento ParseToPlanoPagamento(PlanoPagamento planoPagamento)
        {
            planoPagamento.Nome = Nome;
            planoPagamento.Periodicidade = Periodicidade;
            planoPagamento.DataPrimeiraParcela = DataPrimeiraParcela;
            planoPagamento.Desconto = Desconto;
            planoPagamento.Juros = Juros;
            planoPagamento.Multa = Multa;
            planoPagamento.DataAlteracao = DataAlteracao;
            planoPagamento.UsuarioAlteracao = UsuarioAlteracao;
            planoPagamento.Ativo = Ativo;

            return planoPagamento;
        }
    }
}