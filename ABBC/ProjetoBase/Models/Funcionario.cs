using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Funcionario : BaseModel
    {

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public int NivelAcessso { get; set; }

        /// <summary>
        /// Flag que indica se o Aluno foi excluido
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data alteração dados 
        /// </summary>
        public DateTime DataAlteracao { get; set; }

    }
}