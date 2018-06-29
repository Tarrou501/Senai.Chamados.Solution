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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ListaUsuarioViewModel vmListaUsuario= new ListaUsuarioViewModel();

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
            {
                vmListaUsuario.ListaUsuarios = Mapper.Map<List<UsuarioDomain> ,List<UsuarioViewModel>>(_repUsuario.Listar());
            }
            return View(vmListaUsuario);
        }
    }
}