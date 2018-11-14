using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Pais : BaseModel
    {
        /// <summary>
        /// Codigo País
        /// </summary>
        public int CodPais { get; set; }
        /// <summary>
        /// Sigla País
        /// </summary>
        public string SglPais { get; set; }
        /// <summary>
        /// Nome País
        /// </summary>
        public string NomePais { get; set; }
    }
}