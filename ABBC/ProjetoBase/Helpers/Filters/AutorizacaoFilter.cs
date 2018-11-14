using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProjetoBase.Models;

namespace ProjetoBase.Helpers.Filters
{
    [ExceptionFilter]
    public class AutorizacaoFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = SessionHelper.UsuarioLogado;

            bool precisaLogar = false;
            bool semPermissao = false;
            
            if (user != null)
            {
                precisaLogar = false;
                //Editar
            }
            else
            {
                precisaLogar = true;
            }

            if (semPermissao)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "SemPermissao",
                    controller = "Dashboards",
                    area = ""
                }));
            }

            if (precisaLogar)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Autenticacao",
                }));
            }
        }
    }
}
