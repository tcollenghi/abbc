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
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new FuncionarioDTO());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(FuncionarioDTO funcionario)
        {
            var erros = funcionario.validate();

            if (erros.Count == 0)
            {
                Funcionario funcionarios = funcionario.ParseToFuncionario();

                FuncionarioDao.Save(funcionarios);
                SessionHelper.AddMensagemToView("Funcionario criado com sucesso");

                return RedirectToAction("Index", "Funcionario");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(funcionario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdFuncionario"></param>
        /// <returns></returns>
        public ActionResult Edit(int IdFuncionario)
        {
            Funcionario funcionarios = FuncionarioDao.FindAllByIDFuncionario(IdFuncionario);

            ViewBag.ID = IdFuncionario;
            ViewBag.erros = new List<string>();
            return View(new FuncionarioDTO(funcionarios));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(FuncionarioDTO funcionario)
        {
            var erros = funcionario.validateEdit();

            if (erros.Count == 0)
            {
                Funcionario funcionarios = FuncionarioDao.Find(funcionario.ID);

                funcionarios = funcionario.ParseToFuncionario(funcionarios);
                FuncionarioDao.SaveUpdateAll();

                SessionHelper.AddMensagemToView("Funcionario editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;

            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View(funcionario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFuncionario(long ID)
        {
            Funcionario labUpdate = FuncionarioDao.FindAllByIDFuncionario(ID);

            FuncionarioDao.Delete(labUpdate);
            return Json("Response from Delete");
        }

        public ActionResult CreateFuncionarioUser(int IdFuncionario)
        {
            Funcionario funcionarios = FuncionarioDao.FindAllByIDFuncionario(IdFuncionario);
            ViewBag.ID = IdFuncionario;

            int contaSeExiste = UsuarioDao.countByName(funcionarios.Nome);
            if (contaSeExiste > 0)
            {
                Usuario user = UsuarioDao.FindByName(funcionarios.Nome);
                ViewBag.Login = user.login;
                ViewBag.Senha = user.senha;
                ViewBag.NivelAcesso = user.funcao;
            }

           
            ViewBag.erros = new List<string>();
            return View();
        }
        [HttpPost]
        public ActionResult CreateFuncionarioUser(int ID, string Login, string Senha, string NivelAcessso)
        {
            int erros = 0;
            int nivelFuncionario = 0;

            if (ID == 0)
            {
                erros = 1;
            }

            if (Login == "")
            {
                erros = 1;
            }

            if (Senha == "")
            {
                erros = 1;
            }

            if (NivelAcessso == "")
            {
                erros = 1;
            }
            else
            {
                switch (NivelAcessso)
                {
                    case "Administrador": nivelFuncionario = 1;
                        break;
                    case "Leitura": nivelFuncionario = 2;
                        break;
                    case "Presença e Observações": nivelFuncionario = 3;
                        break;
                    default:
                        break;
                }
            }

            if (erros == 0)
            {
                Funcionario funcionarios = FuncionarioDao.FindAllByIDFuncionario(ID);
                funcionarios.NivelAcessso = nivelFuncionario;
                FuncionarioDao.SaveUpdateAll();

                int contaSeExiste = UsuarioDao.countByName(funcionarios.Nome);

                if (contaSeExiste > 0)
                {
                    Usuario usuario = UsuarioDao.FindByName(funcionarios.Nome);

                    usuario.login = Login;
                    usuario.senha = Senha;
                    usuario.funcao = NivelAcessso;

                    UsuarioDao.SaveUpdateAll();
                }
                else
                {
                    Usuario u = new Usuario
                    {
                        nome = funcionarios.Nome,
                        login = Login,
                        senha = Senha,
                        funcao = NivelAcessso,
                        ativo = true
                    };

                    UsuarioDao.Save(u);
                }


                SessionHelper.AddMensagemToView("Funcionario atualizado com sucesso");

                return RedirectToAction("Index", "Funcionario");
            }
            ViewBag.erros = erros;
            SessionHelper.AddMensagemToView("Revise os campos destacados", MensagemDTO.EnumTipoMensagem.info);
            return View();
        }

    }
}