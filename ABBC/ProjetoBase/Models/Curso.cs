
using System;

namespace ProjetoBase.Models
{
    public class Curso : BaseModel
    {
        /// <summary>
        /// Nome do Curso
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Carga Horaria do Curso
        /// </summary>
        public string CargaHoraria { get; set; }

        /// <summary>
        /// Data alteração dados do curso
        /// </summary>
        public DateTime DataAlteracao { get; set; }

        /// <summary>
        /// Flag que indica se o Curso esta ativo ou não
        /// </summary>
        public bool Ativo { get; set; }

    }
}