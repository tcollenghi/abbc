using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Log : BaseModel
    {
        /// <summary>
        /// Nome do usuario
        /// </summary>
        public string nomeUsuario { get; set; }

        /// <summary>
        /// Menu do log (Ex.: administração)
        /// </summary>
        public string menu { get; set; }

        /// <summary>
        /// Opção escolhida (Ex.: Aprovar)
        /// </summary>
        public string opcao { get; set; }

        /// <summary>
        /// Ação realizada	(Ex.: Artigo id 987)
        /// </summary>
        public string acao { get; set; }

        /// <summary>
        /// Ação realizada	(Ex.: Artigo id 987)
        /// </summary>
        [MaxLength(4)]
        public string method { get; set; }

        /// <summary>
        /// Data da ação
        /// </summary>
        public DateTime data { get; set; }
    }
}