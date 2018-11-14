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
    public class AlunoController : Controller
    {
        // GET: Aluno
        
        public ActionResult Index()
        {
            return View(AlunoDao.FindAll());
        }
        
        public ActionResult Create()
        {
            return View(new AlunoDTO());
        }
        
        [HttpPost]
        public ActionResult Create(AlunoDTO aluno)
        {
            var erros = aluno.validate();

            if (erros.Count == 0)
            {
                Aluno usuario = aluno.ParseToAluno();

                AlunoDao.Save(usuario);
                SessionHelper.AddMensagemToView("Aluno criado com sucesso");

                return RedirectToAction("Index", "Aluno");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(aluno);
        }
        
        public ActionResult Edit(int IdAluno)
        {
            Aluno aluno = AlunoDao.FindAllByIDAluno(IdAluno);

            ViewBag.ID = IdAluno;
            ViewBag.erros = new List<string>();
            return View(new AlunoDTO(aluno));
        }
        
        [HttpPost]
        public ActionResult Edit(AlunoDTO aluno)
        {
            var erros = aluno.validateEdit();

            if (erros.Count == 0)
            {
                Aluno usuario = AlunoDao.Find(aluno.ID);

                usuario = aluno.ParseToAluno(usuario);
                AlunoDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Aluno editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(aluno);
        }
        
        public ActionResult AlunoLinqCursoTurma(int aluno)
        {
            ViewBag.ID = aluno;
            return View();
        }
        
        [HttpPost]
        public ActionResult AlunoLinqCursoTurma(int idAluno, int idCurso, int idTurma, int idPlanoPagamento)
        {
            try
            {
                int id = idAluno;
                int curso = idCurso;
                int turma = idTurma;
                int planoPagamento = idPlanoPagamento;

                var erros = AlunoDao.validate(curso, turma);

                if (erros.Count == 0)
                {
                    Aluno update = AlunoDao.Find(id);
                    update.Curso = curso;
                    update.Turma = turma;
                    update.PlanoPagamento = planoPagamento;

                    AlunoDao.SaveUpdateAll();

                    SessionHelper.AddMensagemToView("Aluno atualizado com sucesso");
                    return RedirectToAction("Index", "Aluno");
                }

                ViewBag.erros = erros;

                SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet]
        public JsonResult getAlunoDetails(int userId)
        {
            IList<Aluno> FoodList = new List<Aluno>();

            FoodList = AlunoDao.FindAllByIDs(userId);

            return Json(new { FoodList = FoodList }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult DeleteAluno(long ID)
        {
            Aluno labUpdate = AlunoDao.FindAllByIDAluno(ID);

            AlunoDao.Delete(labUpdate);
            return Json("Response from Delete");
        }
    }
}