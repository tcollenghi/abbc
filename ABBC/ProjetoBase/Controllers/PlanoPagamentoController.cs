using System.Collections.Generic;
using System.Web.Mvc;
using ProjetoBase.DTO;
using ProjetoBase.DAO;
using ProjetoBase.Service;
using ProjetoBase.Models;
using ProjetoBase.Helpers;
using ProjetoBase.Helpers.Filters;
using System.Threading.Tasks;
using System;
using System.Net;
using System.IO;

namespace ProjetoBase.Controllers
{
    [ActionFilter]
    [LogFilter]
    [AutorizacaoFilter]
    [ExceptionFilter]
    public class PlanoPagamentoController : Controller
    {

        // GET: PlanoPagamento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View(new PlanoPagamentoDTO());
        }
        public ActionResult Gerar()
        {
            return View();
        }


        public ActionResult Edit(int IdPlanoPagamento)
        {
            PlanoPagamento pp = PlanoPagamentoDao.FindAllByIDPlanoPagamento(IdPlanoPagamento);

            ViewBag.ID = IdPlanoPagamento;
            ViewBag.erros = new List<string>();
            return View(new PlanoPagamentoDTO(pp));
        }

        [HttpPost]
        public ActionResult Edit(PlanoPagamentoDTO pp)
        {
            var erros = pp.validateEdit();

            if (erros.Count == 0)
            {
                PlanoPagamento pps = PlanoPagamentoDao.Find(pp.ID);

                pps = pp.ParseToPlanoPagamento(pps);
                PlanoPagamentoDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Plano editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(pp);
        }

        [HttpPost]
        public ActionResult Create(PlanoPagamentoDTO plano)
        {
 


            var erros = plano.validate();

            if (erros.Count == 0)
            {
                PlanoPagamento planos = plano.ParseToPlanoPagamento();

                PlanoPagamentoDao.Save(planos);
                SessionHelper.AddMensagemToView("Plano de Pagamento criado com sucesso");

                return RedirectToAction("Index", "PlanoPagamento");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(plano);
        }


        [HttpPost]
        public JsonResult DeletePlanoPagamento(long ID)
        {
            PlanoPagamento labUpdate = PlanoPagamentoDao.FindAllByIDPlanoPagamento(ID);

            PlanoPagamentoDao.Delete(labUpdate);
            return Json("Response from Delete");
        }

  


    }
}