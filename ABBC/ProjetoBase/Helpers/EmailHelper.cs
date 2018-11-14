using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ProjetoBase.Models;

namespace ProjetoBase.Helpers
{
    public class EmailHelper
    {
        
        private static void SendEmail(string emailTo, List<string> cc, string assunto, string corpo)
        {
            var fromAddress = new MailAddress("sollodbmail@sollobrasil.com.br", "Projeto Base");
            var toAddress = new MailAddress(emailTo, "");
            
            var smtp = new SmtpClient
            {
                Host = "correio.sollobrasil.com.br",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("sollodbmail", "maildb512#")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = true,
            })
            {
                cc.ForEach(x => message.CC.Add(x));
                smtp.Send(message);
            }
        }
        
    }
}