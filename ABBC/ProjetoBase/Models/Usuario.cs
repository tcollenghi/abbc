using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Usuario : BaseModel
    {

        /// <summary>
        /// Nome do usuario
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// login para entrar no sistema
        /// </summary>
        public string login { get; set; }

        /// <summary>
        /// Senha para entrar no sistema
        /// </summary>
        public string senha { get; set; }

        /// <summary>
        /// E-mail do usuário
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Função do usuário
        /// </summary>
        public string funcao { get; set; }

        /// <summary>
        /// Lista de logs do usuario
        /// </summary>
        public virtual List<Log> logs { get; set; }

        /// <summary>
        /// Flag que indica se o usuario foi excluido
        /// </summary>
        public bool ativo { get; set; }

        public Usuario()
        {

            logs = new List<Log>();

        }
    }
}