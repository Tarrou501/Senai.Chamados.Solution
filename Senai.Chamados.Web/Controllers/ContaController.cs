using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels;
using System;
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

            // Lembrar de instalar o Entity Framework
            SenaiChamadosDBContext objDbContext = new SenaiChamadosDBContext();
            UsuarioDomain objUsuario = new UsuarioDomain();
            try
            {
                objUsuario.id = Guid.NewGuid();
                objUsuario.Nome = usuario.Nome;
                objUsuario.Email = usuario.Email;
                objUsuario.Senha = usuario.Senha;
                objUsuario.Telefone = usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
                objUsuario.Cpf = usuario.Cpf.Replace(".","").Replace("-","");
                objUsuario.Logradouro = usuario.Logradouro;
                objUsuario.Numero = usuario.Numero;
                objUsuario.Complemento = usuario.Complemento;
                objUsuario.Bairro = usuario.Bairro;
                objUsuario.Cep = usuario.Cep.Replace("-", "");
                objUsuario.Cidade = usuario.Cidade;
                objUsuario.Estado = usuario.Estado;
                objUsuario.DataAlteracao = DateTime.Now;
                objUsuario.DataCriacao = DateTime.Now;

                objDbContext.Usuarios.Add(objUsuario);
                objDbContext.SaveChanges();

                TempData["Messagem"] = "Usuário cadastrado";
                return RedirectToAction("Login");
            }
            catch(System.Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(usuario);
            }
            finally
            {
                objDbContext = null;
                objUsuario = null;
            }
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