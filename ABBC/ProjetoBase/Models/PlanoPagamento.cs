using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class PlanoPagamento : BaseModel
    {
        /// <summary>
        /// •	Nome do Plano de Pagamento
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// •	Número de parcelas
        /// </summary>
        public int NumeroParcelas { get; set; }
        /// <summary>
        /// •	Periodicidade: Mensal/ Anual
        /// </summary>
        public string Periodicidade { get; set; }
        /// <summary>
        /// •	Data da 1ª parcela: Dia/Mês/ Ano
        /// </summary>
        public DateTime DataPrimeiraParcela { get; set; }
        /// <summary>
        /// •	Desconto: (R$) / Conceder o desconto até a data de vencimento
        /// </summary>
        public string Desconto { get; set; }
        /// <summary>
        /// •	Juros: 0,033% ao dia (Após a data de vencimento)
        /// </summary>
        public string Juros { get; set; }
        /// <summary>
        /// •	Multa: 2% do valor
        /// </summary>
        public string Multa { get; set; }
        /// <summary>
        /// •	Data de Alteração
        /// </summary>
        public DateTime DataAlteracao { get; set; }
        /// <summary>
        /// •	Usuario Alteracao
        /// </summary>
        public string UsuarioAlteracao { get; set; }
        /// <summary>
        /// •	Indica de o Plano de Pagamento esta ativo
        /// </summary>
        public bool Ativo { get; set; }
    }
}