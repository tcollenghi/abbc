using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.DTO;
using ProjetoBase.Service;
using ProjetoBase.Helpers;
using ProjetoBase.Helpers.Filters;

namespace ProjetoBase.Controllers
{
    public class AutenticacaoController : Controller
    {
        /// <summary>
        /// Login do sistema
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View(new UsuarioSimplesDTO());
        }

        /// <summary>
        /// Login do sistema
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UsuarioSimplesDTO login)
        {
            bool autenticado = AutenticacaoService.login(login);
            if (autenticado)
            {
                return RedirectToAction("Index", "Dashboards");
            }
            SessionHelper.AddMensagemToView("Login não encotrado", MensagemDTO.EnumTipoMensagem.error);
            return View(login);
        }

        /// <summary>
        /// Sair do sistema
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            SessionHelper.abandonarSession();
            SessionHelper.UsuarioLogado = null;
            return RedirectToAction("Login");
        }
    }
}