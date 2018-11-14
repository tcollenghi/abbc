using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Models;

namespace ProjetoBase.DTO
{
    public class LogDTO 
    {
        public long ID { get; set; }
        public string nomeUsuario { get; set; }
        public string menu { get; set; }
        public string opcao { get; set; }
        public string acao { get; set; }
        public string method { get; set; }
        public string data { get; set; }

        public LogDTO()
        {

        }

        public LogDTO(Log log)
        {
            ID = log.ID;
            nomeUsuario = log.nomeUsuario;
            menu = log.menu;
            opcao = log.opcao;
            acao = log.acao;
            method = log.method;
            data = log.data.ToString("dd/MM/yyy HH:mm:ss");
        }

        public static List<LogDTO> ParseList(List<Log> logs)
        {
            var logsDTO = new List<LogDTO>();
            foreach (var log in logs)
            {
                logsDTO.Add(new LogDTO(log));
            }
            return logsDTO;
        }
    }
}