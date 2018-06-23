using Senai.Chamados.Web.ViewModels;

using System.Collections.Generic;


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

            // Valida Usuário
            if (login.Email =="senai@senai.sp" && login.Senha =="123")
            {
                TempData["Autenticado"] = "Usuário Autenticado";
                // Redireciona para a página Home

                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["Autenticado"] = "Usuário não cadastrado";
                // Redireciona para a página de Cadastro de usuário
                return RedirectToAction("CadastrarUsuario");
            }

            // Não faz mais sentido, pois foi implementado o return acima.
            //return View();
        }

        [HttpGet]
        public ActionResult CadastrarUsuario()
        {
            CadastrarUsuarioViewModel objCadastrarUsuario = new CadastrarUsuarioViewModel();

            // teste para verificar a visualização na tela
            //objCadastrarUsuario.Nome = "Leonardo";
            //objCadastrarUsuario.Email = "Leonardo@gmail.com.br";

            objCadastrarUsuario.Sexo = ListaSexo();

            return View(objCadastrarUsuario);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            usuario.Sexo = ListaSexo();
            if (!ModelState.IsValid) {
                ViewBag.Erro = "Dados inválido";
                return View(usuario);
            }

            return View(usuario);
        }

        private SelectList ListaSexo()
        {
             return  new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem {Text ="masculino", Value = "1" },
                    new SelectListItem {Text ="Feminino", Value = "2"},
                }, "Value", "Text");

        }
    }
}