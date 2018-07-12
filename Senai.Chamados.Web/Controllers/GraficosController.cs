using AutoMapper;
using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Domain.Enum;
using Senai.Chamados.Web.ViewModels.Chamados;
using Senai.Chamados.Web.ViewModels.Grafico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
 
    public class GraficosController : Controller
    {

        [Authorize]
        // GET: Graficos
        public ActionResult Index()
        {
            try
            {
                ListaGraficoViewModel vmGrafico = new ListaGraficoViewModel();
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

                #region Grafico Status
                // Faz o agrupamento dos dados por status
                var grupoStatus = vmListaChamados.ListaChamados
                    .GroupBy(x => x.Status)
                    .Select(n => new
                    {
                        Status = RetornaStatus(n.Key),
                        Quantidade = Convert.ToDouble(n.Count())
                    }).OrderBy(n => n.Quantidade);

                // Atribui as labels que serão mostradas no gráfico
                vmGrafico.GraficoStatus.Labels = grupoStatus.Select(x => x.Status).ToArray();

                // Atribui os dados que serão apresentadas no grafico
                vmGrafico.GraficoStatus.Data = grupoStatus.Select(x => x.Quantidade).ToArray();
                #endregion


                #region Grafico Setor
                // Faz o agrupamento dos dados por status
                var grupoSetor = vmListaChamados.ListaChamados
                    .GroupBy(x => x.Setor)
                    .Select(n => new
                    {
                        Setor = RetornaSetor(n.Key),
                        Quantidade = Convert.ToDouble(n.Count())
                    }).OrderBy(n => n.Quantidade);

                // Atribui as labels que serão mostradas no gráfico
                vmGrafico.GraficoSetor.Labels = grupoSetor.Select(x => x.Setor).ToArray();

                // Atribui os dados que serão apresentadas no grafico
                vmGrafico.GraficoSetor.Data = grupoSetor.Select(x => x.Quantidade).ToArray();
                #endregion

                return View(vmGrafico);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }           
            
        }

        private string RetornaStatus(EnStatus status)
        {
            switch (status)
            {
                case EnStatus.Aguardando:
                    return "Aguardando";
                case EnStatus.Iniciado:
                    return "Iniciado";
                    
                case EnStatus.Finalizado:
                    return "Finalizado";                
            }
            return null;
        }


        private string RetornaSetor(EnSetor setor)
        {
            switch (setor)
            {
                case EnSetor.Administrativo:
                    return "Administrativo";
                case EnSetor.Informatica:
                    return "Informática";

                case EnSetor.Recepcao:
                    return "Receção";
            }
            return null;
        }

    }


}