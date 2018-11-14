using System.Collections.Generic;
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
    public class TurmaController : Controller
    {
        // GET: Turma
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View(new TurmaDTO());
        }
        
        [HttpPost]
        public ActionResult Create(TurmaDTO turma)
        {
            var erros = turma.validate();

            if (erros.Count == 0)
            {
                Turma turmas = turma.ParseToTurma();

                TurmaDao.Save(turmas);
                SessionHelper.AddMensagemToView("Turma criada com sucesso");

                return RedirectToAction("Index", "Turma");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(turma);
        }

        public ActionResult Edit(int IdTurma)
        {
            Turma turma = TurmaDao.FindAllByIDTurma(IdTurma);

            ViewBag.ID = IdTurma;
            ViewBag.erros = new List<string>();
            return View(new TurmaDTO(turma));
        }

        [HttpPost]
        public ActionResult Edit(TurmaDTO turma)
        {
            var erros = turma.validateEdit();

            if (erros.Count == 0)
            {
                Turma turmas = TurmaDao.Find(turma.ID);

                turmas = turma.ParseToTurma(turmas);
                TurmaDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Turma editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(turma);
        }

        [HttpPost]
        public JsonResult DeleteTurma(long ID)
        {
            Turma labUpdate = TurmaDao.FindAllByIDTurma(ID);

            TurmaDao.Delete(labUpdate);
            return Json("Response from Delete");
        }


    }
}