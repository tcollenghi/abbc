using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using ProjetoBase.Helpers.Exceptions;
using ProjetoBase.Models;

namespace ProjetoBase.Helpers.Filters
{
    public class ExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        private static readonly string FILE_EXCEPTION_LOG = HostingEnvironment.ApplicationPhysicalPath + "\\ExceptionLogs";

        public void OnException(ExceptionContext filterContext)
        {
            try
            {
                if (filterContext.Exception is SemPermissaoException)
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Dashboards" },
                        { "action", "SemPermissao" }
                    });
                    filterContext.ExceptionHandled = true;
                }
                if (!Directory.Exists(FILE_EXCEPTION_LOG))
                {
                    Directory.CreateDirectory(FILE_EXCEPTION_LOG);
                }
                ExceptionToFile(filterContext.Exception);
            }
            catch (Exception e)
            {
                var db = new ProjetoBaseContext();
                Log log = new Log();
                log.nomeUsuario = "EXCEPTION_SISTEMA";
                log.menu = "EXCEPTION_DURANTE_EXCEPTION";
                log.opcao = e.Message + "<br><br>" + e.StackTrace;
                log.data = DateTime.Now;
                db.Log.Add(log);
                db.SaveChanges();
            }
        }

        public static void ExceptionToFile(Exception exception)
        {
            string path = FILE_EXCEPTION_LOG + "\\LOG_" + DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
            
            //Se o arquivo não existe
            if (!File.Exists(path))
            {
                //Cria um arquivo
                FileStream fs = File.Create(path);
                fs.Dispose();
            }
            TextWriter tw = new StreamWriter(path, true);
            var nomeUsuario = "Nenhum Logado";

            //Se nenhum usuário está conectado então sai não guarda log
            if (SessionHelper.UsuarioLogado != null)
            {
                nomeUsuario = SessionHelper.UsuarioLogado.login;
            }

            var descricao = "\r\n\r\n****NEW EXCEPTION: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "****";
            descricao += "\r\n**Usuario: " + nomeUsuario;
            descricao += "\r\n**EXCEPTION TYPE:" + exception.GetType() + "";
            descricao += "\r\n**EXCEPTION:" + exception.Message + ", ";
            descricao += "\r\n**METHOD:" + exception.TargetSite + ", ";
            descricao += "\r\n**STACKTRACE:" + exception.StackTrace + ", ";

            var inner = exception.InnerException;

            while (inner != null)
            {
                descricao += "\r\n**INNER:" + inner.Message;
                descricao += "\r\n**STACKTRACE:" + inner.StackTrace;
                inner = inner.InnerException;
            }
            tw.WriteLine(descricao);
            tw.Close();
        }
   
    }
}
