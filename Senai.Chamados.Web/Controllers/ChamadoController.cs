using AutoMapper;
using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels.Chamados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    [Authorize]
    public class ChamadoController : Controller
    {
        // GET: Chamado
        public ActionResult Index()
        {
            ListaChamadoViewModel vmListaChamados = new ListaChamadoViewModel();

            using (ChamadoRepositorio _repChamado = new ChamadoRepositorio())
            {

                if (User.IsInRole("Administrador"))
                {
                    vmListaChamados.ListaChamados = Mapper.Map<List<ChamadoDomain>, List<ChamadoViewModel>>(_repChamado.Listar());
                }
                else
                {
                    var claims = User.Identity as ClaimsIdentity;
                    var id = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                    vmListaChamados.ListaChamados = Mapper.Map<List<ChamadoDomain>, List<ChamadoViewModel>>(_repChamado.Listar(new System.Guid(id)));
                }
                
            }
            return View(vmListaChamados);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ChamadoViewModel vmChamado = new ChamadoViewModel();
            return View(vmChamado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ChamadoViewModel chamado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Erro = "Dados inválidos";
                    return View(chamado);
                }

                using (ChamadoRepositorio objRepoChamado = new ChamadoRepositorio())
                {
                    var identity = User.Identity as ClaimsIdentity;
                    var id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    chamado.IdUsuario = new Guid(id);
                    objRepoChamado.Inserir(Mapper.Map<ChamadoViewModel,ChamadoDomain>(chamado));
                }
                TempData["Sucesso"] = "Chamado Cadastrado. Aguarde!!";
                return RedirectToAction("Index");
            }
            catch(Exception ex) {
                ViewBag.Erro = ex.Message;
                return View(chamado);
            }            
        }

        [HttpGet]
        //public ActionResult Editar(string id = null) 
        public ActionResult Editar(Guid? id)
        {
            ChamadoViewModel objChamado = new  ChamadoViewModel();
            try
            {
                if (id == null)
                {
                    TempData["Erro"] = "id não identificado";
                    return RedirectToAction("Index");
                }


                using (ChamadoRepositorio objRepoChamado = new ChamadoRepositorio())
                {
                    //objChamado = Mapper.Map<ChamadoDomain, ChamadoViewModel>(objRepoChamado.BuscarPorId(new Guid(id)));
                    objChamado = Mapper.Map<ChamadoDomain, ChamadoViewModel>(objRepoChamado.BuscarPorId(id.Value ));
                    if (objChamado == null)
                    {
                        TempData["Erro"] = "Chamado não encontrado";
                        return RedirectToAction("Index");
                    }

                    #region Buscar Id Usuario
                    var identity = User.Identity as ClaimsIdentity;
                    var IdUsuario = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    #endregion

                    if (User.IsInRole("Administrador") || IdUsuario == objChamado.IdUsuario.ToString()) {
                        return View(objChamado);
                    }
                    else
                    {
                        TempData["Erro"] = "Este Chamado pertence a outro usuário";
                        return RedirectToAction("Index");
                    }                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(objChamado);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ChamadoViewModel chamado)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Erro = "Dados invaliado";
                    return View(chamado);
                }


                using (ChamadoRepositorio objRepoChamado = new ChamadoRepositorio())
                {
                    objRepoChamado.Alterar(Mapper.Map<ChamadoViewModel, ChamadoDomain>(chamado));

                    TempData["Sucesso"] = "Chamado alterado";
                    return RedirectToAction("Index");
                    
                }

            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }


        [HttpGet]
        //public ActionResult Deletar(string id= null)
        public ActionResult Deletar(Guid? id )
        {
            ChamadoViewModel objChamado = new ChamadoViewModel();
            try
            {
                if (id == null)
                {
                    TempData["Erro"] = "Informe o id do chamado";
                    return RedirectToAction("Index");
                }

  
                using (ChamadoRepositorio objRepoChamado = new ChamadoRepositorio())
                {
                    //objChamado = Mapper.Map<ChamadoDomain, ChamadoViewModel>(objRepoChamado.BuscarPorId(new Guid(id)));
                    objChamado = Mapper.Map<ChamadoDomain, ChamadoViewModel>(objRepoChamado.BuscarPorId(id.Value));

                    if (objChamado == null)
                    {
                        TempData["Erro"] = "Chamado não encontrado";
                        return RedirectToAction("Index");
                    }

                    #region Buscar Id Usuario
                    var identity = User.Identity as ClaimsIdentity;
                    var IdUsuario = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    #endregion

                    if (User.IsInRole("Administrador") || IdUsuario == objChamado.IdUsuario.ToString())
                    {
                        return View(objChamado);
                    }
                    else
                    {
                        TempData["Erro"] = "Você não possui permissão para excluir este chamado";
                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {

                ViewBag.Erro = ex.Message;
                return View(objChamado);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(ChamadoViewModel chamado)
        {
            try
            {
                if (chamado.Id == Guid.Empty)
                {
                    TempData["Erro"] = "Informe o id do chamado";
                    return RedirectToAction("Index");
                }

                using (ChamadoRepositorio objRepoChamado = new ChamadoRepositorio())
                {
                    ChamadoViewModel objChamado = Mapper.Map<ChamadoDomain, ChamadoViewModel>(objRepoChamado.BuscarPorId(chamado.Id));
                    if (objChamado == null)
                    {
                        TempData["Erro"] = "Chamado não encontrado";
                        return RedirectToAction("Index");
                    }

                    objRepoChamado.Deletar(Mapper.Map<ChamadoViewModel, ChamadoDomain>(objChamado));
                    TempData["Sucesso"] = "Chamado excluído";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                ViewBag.Erro = ex.Message;
                return View(chamado);
            }
            
        }
    }
}
