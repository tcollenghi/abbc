using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Estado : BaseModel
    {
        /// <summary>
        /// Codigo do Estado
        /// </summary>
        public int CodEstado { get; set; }
        /// <summary>
        /// Codigo do País
        /// </summary>
        public int CodPais { get; set; }
        /// <summary>
        /// Sigla do Estado
        /// </summary>
        public string SglEstado { get; set; }
        /// <summary>
        /// Nome do Estado
        /// </summary>
        public string NomeEstado { get; set; }
    }
}