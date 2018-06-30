using AutoMapper;
using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Data.Repositorios;
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Login inválido";
                return View();
            }

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                UsuarioDomain objUsuario = _repUsuario.Login(login.Email, login.Senha);
                if(objUsuario != null)
                {
                    return  RedirectToAction("Index", "Usuario");                   
                }
                else
                {
                    ViewBag.Erro = "Usuario ou senha inválido, Tente novamente";
                    return View(login);
                }


            }

                // Valida Usuário
                //if (login.Email == "senai@senai.sp" && login.Senha == "123")
                //{
                //    TempData["Autenticado"] = "Usuário Autenticado";
                //    // Redireciona para a página Home

                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    TempData["Autenticado"] = "Usuário não cadastrado";
                //    // Redireciona para a página de Cadastro de usuário
                //    return RedirectToAction("CadastrarUsuario");
                //}

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
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            usuario.Sexo = ListaSexo();
            if (!ModelState.IsValid) {
                ViewBag.Erro = "Dados inválido";
                return View(usuario);
            }

            // Lembrar de instalar o Entity Framework

            // Utilizamos UsuarioRepositorio _repositorio em vez de SenaiChamadosDBContext
            //SenaiChamadosDBContext objDbContext = new SenaiChamadosDBContext();

            UsuarioDomain objUsuario = new UsuarioDomain();
            try
            {
                // Não utilizado mais pois foi tratado no onSaveChanged
                //objUsuario.id = Guid.NewGuid();
                //objUsuario.DataAlteracao = DateTime.Now;
                //objUsuario.DataCriacao = DateTime.Now;

                //objUsuario.Nome = usuario.Nome;
                //objUsuario.Email = usuario.Email;
                //objUsuario.Senha = usuario.Senha;
                //objUsuario.Telefone = usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
                //objUsuario.Cpf = usuario.Cpf.Replace(".","").Replace("-","");
                //objUsuario.Cep = usuario.Cep.Replace("-", "");
                //objUsuario.Logradouro = usuario.Logradouro;
                //objUsuario.Numero = usuario.Numero;
                //objUsuario.Complemento = usuario.Complemento;
                //objUsuario.Bairro = usuario.Bairro;
                //objUsuario.Cidade = usuario.Cidade;
                //objUsuario.Estado = usuario.Estado;

                // Não é mai necessário pois implementado a classe UsuarioRepositorio
                //objDbContext.Usuarios.Add(objUsuario);
                //objDbContext.SaveChanges();

                usuario.Telefone = usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
                usuario.Cpf = usuario.Cpf.Replace(".","").Replace("-","");
                usuario.Cep = usuario.Cep.Replace("-", "");

                using (UsuarioRepositorio _repositorio = new UsuarioRepositorio())
                {
                    //_repositorio.Inserir(objUsuario);
                    _repositorio.Inserir(Mapper.Map<CadastrarUsuarioViewModel,UsuarioDomain>(usuario));
                }

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
              //  objDbContext = null;
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