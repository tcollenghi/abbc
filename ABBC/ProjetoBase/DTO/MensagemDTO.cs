using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.DTO
{
    public class MensagemDTO
    {
        public enum EnumTipoMensagem
        {
            success = 1,
            error = 2,
            info = 3,
        }
        
        public string primaria { get; set; }
        public string secundaria { get; set; }
        public EnumTipoMensagem _tipo { get; set; }
        public string tipo
        {
            get
            {
                return _tipo.ToString();
            }
        }
        public MensagemDTO() { }
        
        /// <summary>
        /// Mensagem primaria de sucesso
        /// </summary>
        /// <param name="mensagem"></param>
        public MensagemDTO(string mensagemPrimaria) {
            this.primaria = mensagemPrimaria;
            this.secundaria = "";
            this._tipo = EnumTipoMensagem.success;
        }

        public MensagemDTO(string mensagemPrimaria, string mensagemSecundaria) {
            this.primaria = mensagemPrimaria;
            this.secundaria = mensagemSecundaria;
            this._tipo = EnumTipoMensagem.success;
        }

        public MensagemDTO(string mensagemPrimaria, EnumTipoMensagem tipo) {
            this.primaria = mensagemPrimaria;
            this.secundaria = "";
            this._tipo = tipo;
        }

        public MensagemDTO(string mensagemPrimaria, string mensagemSecundaria, EnumTipoMensagem tipo) {
            this.primaria = mensagemPrimaria;
            this.secundaria = mensagemSecundaria;
            this._tipo = tipo;
        }

    }
}