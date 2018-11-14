using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Turma : BaseModel
    {
        /// <summary>
        /// Nome do Turma
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data alteração dados da Turma
        /// </summary>
        public DateTime DataAlteracao { get; set; }

        /// <summary>
        /// Flag que indica se a Turma esta ativo ou não
        /// </summary>
        public bool Ativo { get; set; }
    }
}