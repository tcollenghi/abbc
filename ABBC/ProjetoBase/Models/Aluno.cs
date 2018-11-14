using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Models
{
    public class Aluno : BaseModel
    {
        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Email do Aluno
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telefone do Aluno
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Telefone do Contato
        /// </summary>
        public string TelefoneContato { get; set; }
        /// <summary>
        /// CPF do Aluno
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// RG Aluno
        /// </summary>
        public string RG { get; set; }
        /// <summary>
        /// Nome Contratante
        /// </summary>
        public string Contratante { get; set; }
        /// <summary>
        /// Filiacao Mae
        /// </summary>
        public string Filiacao { get; set; }
        /// <summary>
        /// Endereco Aluno
        /// </summary>
        public string Endereco { get; set; }
        /// <summary>
        /// Numero Endereço Aluno
        /// </summary>
        public string Numero { get; set; }
        /// <summary>
        /// Bairro Endereço Aluno
        /// </summary>
        public string Bairro { get; set; }
        /// <summary>
        /// Pais
        /// </summary>
        public int Pais { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }
        /// <summary>
        /// CEP
        /// </summary>
        public string CEP { get; set; }
        /// <summary>
        /// Telefone do Contratante
        /// </summary>
        public string TelefoneContratante { get; set; }
        /// <summary>
        /// Vencimento da primeira Parcela
        /// </summary>
        public string VencimentoParcela { get; set; }
        /// <summary>
        /// Curso Aluno
        /// </summary>
        public int Curso { get; set; }
        /// <summary>
        /// Turma Aluno
        /// </summary>
        public int Turma { get; set; }
        /// <summary>
        /// Horario Aula Aluno
        /// </summary>
        public string HorarioAula { get; set; }
        /// <summary>
        /// Dias Da Semana
        /// </summary>
        public string DiasDaSemana { get; set; }
        /// <summary>
        /// Inicio da aula Aluno
        /// </summary>
        public string InicioDeAula { get; set; }
        /// <summary>
        /// Data de Nascimento do Aluno
        /// </summary>
        public DateTime Nascimento { get; set; }
        /// <summary>
        /// Data de Nascimento do Contratante
        /// </summary>
        public DateTime NascimentoContratante { get; set; }
        /// <summary>
        /// Local do Curso
        /// </summary>
        public string LocalCurso { get; set; }
        /// <summary>
        /// PlanoPagamento
        /// </summary>
        public int PlanoPagamento { get; set; }
        /// <summary>
        /// Flag que indica se o Aluno foi excluido
        /// </summary>
        public bool Ativo { get; set; }

    }
}