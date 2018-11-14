using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.DAO;
using ProjetoBase.DTO;
using ProjetoBase.Helpers;
using ProjetoBase.Helpers.Filters;
using ProjetoBase.Models;

namespace ProjetoBase.Controllers
{
    [AutorizacaoFilter]
    [LogFilter]
    [ActionFilter]
    [ExceptionFilter]
    public class DashboardsController : Controller
    {
        public ActionResult Index(string filtro, string ID)
        {
            return View();
        }

        /// <summary>
        /// Sem permissão
        /// </summary>
        /// <returns></returns>
        public ActionResult SemPermissao()
        {
            return View();
        }
    }
}