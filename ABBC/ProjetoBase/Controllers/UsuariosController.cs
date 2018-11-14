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
    public class UsuariosController : Controller
    {
        /// <summary>
        /// Lista de Usuários
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Index()
        {
            return View(AutenticacaoService.listarTodosUsuarios());
        }

        public ActionResult Create()
        {
            return View(new UsuarioSimplesDTO());
        }

        [HttpPost]
        public ActionResult Create(UsuarioSimplesDTO user)
        {
            var erros = user.validate();

            if (erros.Count == 0)
            {
                Usuario usuario = user.ParseToUsuario();

                UsuarioDao.Save(usuario);
                SessionHelper.AddMensagemToView("Usuário criado com sucesso");

                return RedirectToAction("Index", "Dashboards");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(user);
        }

        public ActionResult Edit(string NomeUsuario)
        {
            AutenticacaoService.RecuperaUsuario(NomeUsuario);

            Usuario user = UsuarioDao.FindByLogin(NomeUsuario);

            ViewBag.erros = new List<string>();
            return View(new UsuarioSimplesDTO(user));
        }

        [HttpPost]
        public ActionResult Edit(UsuarioSimplesDTO user)
        {
            var erros = user.validateEdit();

            if (erros.Count == 0)
            {
                Usuario usuario = UsuarioDao.Find(user.ID);

                usuario = user.ParseToUsuario(usuario);
                UsuarioDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Usuário editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(user);
        }

        [AutorizacaoFilter]
        public ActionResult MeuUsuario()
        {
            Usuario user = SessionHelper.UsuarioLogado;

            ViewBag.erros = new List<string>();
            return View(new UsuarioSimplesDTO(user));
        }

        [HttpPost]
        [AutorizacaoFilter]
        public ActionResult MeuUsuario(UsuarioSimplesDTO user)
        {
            var erros = user.validateEdit();
            Usuario usuario = UsuarioDao.FindByLogin(SessionHelper.UsuarioLogado.login);

            if (erros.Count == 0 && user.senha != null && user.senha.Length > 6)
            {
                usuario.senha = user.senha;
                UsuarioDao.SaveUpdateAll();
                SessionHelper.AddMensagemToView("Alterações salvas com sucesso");
                return RedirectToAction("Index", "Dashboards");
            }

            SessionHelper.AddMensagemToView("Senha alterada com sucesso");
            ViewBag.erros = erros;
            return View(new UsuarioSimplesDTO(usuario));
        }

    }
}