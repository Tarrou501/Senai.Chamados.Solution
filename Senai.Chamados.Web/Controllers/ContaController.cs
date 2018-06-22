using Senai.Chamados.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        // Não colocando [HttpGet], já entende que já esta implementado
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Login inválido";
                return View();
            }

            return View();
        }

        [HttpGet]
        public ActionResult CadastrarUsuario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) {
                ViewBag.Erro = "Dados inválido";
                return View();
            }

            return View();
        }
    }
}