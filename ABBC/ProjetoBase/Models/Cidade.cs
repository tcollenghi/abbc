using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Cidade : BaseModel
    {
        /// <summary>
        /// Codigo da Cidade
        /// </summary>
        public int CodCidade { get; set; }
        /// <summary>
        /// Codigo do Estado
        /// </summary>
        public int CodEstado { get; set; }
        /// <summary>
        /// Nome da Cidade
        /// </summary>
        public string NomeCidade { get; set; }
    }
}