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
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View(new CursoDTO());
        }
        
        [HttpPost]
        public ActionResult Create(CursoDTO curso)
        {
            var erros = curso.validate();

            if (erros.Count == 0)
            {
                Curso cursos = curso.ParseToCurso();

                CursoDao.Save(cursos);
                SessionHelper.AddMensagemToView("Curso criado com sucesso");

                return RedirectToAction("Index", "Curso");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(curso);
        }

        public ActionResult Edit(int IdCurso)
        {
            Curso curso = CursoDao.FindAllByIDCurso(IdCurso);

            ViewBag.ID = IdCurso;
            ViewBag.erros = new List<string>();
            return View(new CursoDTO(curso));
        }

        [HttpPost]
        public ActionResult Edit(CursoDTO curso)
        {
            var erros = curso.validateEdit();

            if (erros.Count == 0)
            {
                Curso cursos = CursoDao.Find(curso.ID);

                cursos = curso.ParseToCurso(cursos);
                CursoDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Curso editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(curso);
        }

        [HttpPost]
        public JsonResult DeleteCurso(long ID)
        {
            Curso labUpdate = CursoDao.FindAllByIDCurso(ID);

            CursoDao.Delete(labUpdate);
            return Json("Response from Delete");
        }

    }
}