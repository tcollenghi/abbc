using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.DTO;
using ProjetoBase.DAO;
using ProjetoBase.Service;
using ProjetoBase.Models;
using ProjetoBase.Helpers;
using ProjetoBase.Helpers.Filters;

namespace ProjetoBase.Controllers
{
    [ActionFilter]
    [LogFilter]
    [AutorizacaoFilter]
    [ExceptionFilter]
    public class RelatorioController : Controller
    {
        /// <summary>
        /// Lista de Logs
        /// </summary>
        /// <returns></returns>
        public ActionResult Logs()
        {
            return View();
        }

        [HttpPost]
        [LogFilter(noLog = true)]
        public JsonResult PaginationLogs(DataTableRequest req)
        {
            var resp = LogService.Filter(req);

            return Json(resp);
        }

    }

}
