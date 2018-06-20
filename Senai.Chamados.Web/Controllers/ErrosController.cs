using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    public class ErrosController : Controller
    {
       public ActionResult NaoEncontrado()
        {
            return View();
        }
    }
}