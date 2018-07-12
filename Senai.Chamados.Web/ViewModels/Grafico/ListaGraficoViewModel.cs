using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senai.Chamados.Web.ViewModels.Grafico
{
    public class ListaGraficoViewModel
    {
        public GraficoQuantidadeViewModel GraficoStatus { get; set; }
        public GraficoQuantidadeViewModel GraficoSetor{ get; set; }

        public ListaGraficoViewModel()
        {
            GraficoStatus = new GraficoQuantidadeViewModel();
            GraficoSetor = new GraficoQuantidadeViewModel();
        }
    }
}