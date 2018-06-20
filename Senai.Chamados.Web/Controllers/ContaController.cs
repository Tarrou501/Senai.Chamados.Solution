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
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CadastrarUsuario()
        {

            return View();
        }
    }
}