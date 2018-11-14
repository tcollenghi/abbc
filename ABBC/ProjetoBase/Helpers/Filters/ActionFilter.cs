using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.Models;
using ProjetoBase.DTO;
using ProjetoBase.DAO;
using ProjetoBase.Service;

namespace ProjetoBase.Helpers.Filters
{
    [ExceptionFilter]
    public class ActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Não faz nada
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        { 
            //Não faz nada
        }

    }
}
