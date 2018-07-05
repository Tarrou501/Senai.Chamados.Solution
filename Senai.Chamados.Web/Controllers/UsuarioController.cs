using AutoMapper;
using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    [Authorize(Roles = "Administrador") ]//-> autorização no controlle  e somenete para role Administrador
    public class UsuarioController : Controller
    {
        // GET: Usuario
        //[Authorize]-> autorização somente na ActionResult
        [HttpGet]
        public ActionResult Index()
        {
           // if (!User.IsInRole("Administrador"))
           // {
            //    ViewBag.Erro = " Voce não tem permissão para acessar esta tela.";
            //    return View();
           // }

            ListaUsuarioViewModel vmListaUsuario= new ListaUsuarioViewModel();

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                vmListaUsuario.ListaUsuarios = Mapper.Map<List<UsuarioDomain> ,List<UsuarioViewModel>>(_repUsuario.Listar());
            }
            return View(vmListaUsuario);
        }

        [HttpGet]
        //   [Authorize] // autorização somente na ActionResult
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Guid id)
        {
            if(id == Guid.Empty)
            {
                TempData["Erro"] = "Informe o id do usuário.";
                return RedirectToAction("Index");
            }

            UsuarioViewModel vmUsuario = new UsuarioViewModel();

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                vmUsuario = Mapper.Map<UsuarioDomain, UsuarioViewModel>(_repUsuario.BuscarPorId(id));

                if (vmUsuario == null)
                {
                    TempData["Erro"] = "Usuário não eoncontrado";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(vmUsuario);
                }
            }
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Administrador")]
        public ActionResult Editar (UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados inválidos";
                return View(usuario);
            }

            try
            {
                usuario.Cpf = usuario.Cpf.Replace(".", "").Replace("-", "");
                usuario.Cep = usuario.Cep.Replace("-", "");
                usuario.Telefone = usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

                using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
                {
                    _repUsuario.Alterar(Mapper.Map<UsuarioViewModel, UsuarioDomain>(usuario));
                }
                TempData["Erro"] = "Usuario Editar";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(usuario);
            }
        }

        [HttpGet]        
        public ActionResult Deletar(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["Erro"] = "Informe o id do usuário";
                return RedirectToAction("Index");
            }

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                UsuarioViewModel vmUsuario = Mapper.Map<UsuarioDomain, UsuarioViewModel>(_repUsuario.BuscarPorId(id));
                if (vmUsuario == null)
                {
                    TempData["Erro"] = "Usuario não encontrado";
                    return RedirectToAction("Index");
                }  
                else
                { 

                    return View(vmUsuario);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(UsuarioViewModel usuario)
        {
            if (usuario.Id == Guid.Empty)
            {
                TempData["Erro"] = "Informe o id do usuário";
                return RedirectToAction("Index");
            }

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                UsuarioViewModel vmUsuario = Mapper.Map<UsuarioDomain, UsuarioViewModel>(_repUsuario.BuscarPorId(usuario.Id));
                if (vmUsuario == null)
                {
                    TempData["Erro"] = "Usuario não encontrado";
                    return RedirectToAction("Index");
                }
                else
                {
                    _repUsuario.Deletar(Mapper.Map<UsuarioViewModel, UsuarioDomain>(vmUsuario));
                    TempData["Erro"] = "Usuario excluído";
                    return RedirectToAction("Index");
                }
            }
        }

        
    }
}