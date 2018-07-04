using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels.Conta;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel senha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "Dados inválidos verifique";
                    return View();
                }

                //Obtem claim do usuário
                var identity = User.Identity as ClaimsIdentity;
                //Pega o valor do id do usuário
                var id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                // Obtem o valor de um Claim
                var telefone = identity.Claims.FirstOrDefault(x => x.Type == "Telefone").Value;

                // Cria uma instancia de UsuarioRepositotio
                using (UsuarioRepositorio objRepoUsuario = new UsuarioRepositorio()) {
                    // Busca o usuario pelo Id
                    UsuarioDomain objUsuario = objRepoUsuario.BuscarPorId(new Guid(id));

                    // Verifica se a senha informada é igual a Atual
                    if (senha.SenhaAtual != objUsuario.Senha)
                    {
                        // Senha inválida, informa ao usuário
                        ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                        return View();
                    }

                    // Atribuimos o valor de nova senha ao objeto usuario
                    objUsuario.Senha = senha.NovaSenha;
                    //Alteramos o usuario no banco
                    objRepoUsuario.Alterar(objUsuario);
                    //Definimos a mensagem que irá araecer na tela
                    TempData["Sucesso"] = "Senha alterada";
                    // Retornamos ao Controller Uusario , Index
                    return RedirectToAction("Index","Usuario");
                }                
            }
            catch (System.Exception ex)
            {
                ViewBag.Message = "Ocorreu um erro" + ex.Message;
                return View();
            }
        }
    }
}