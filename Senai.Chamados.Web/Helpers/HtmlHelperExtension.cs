using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString LabelFormSign(this HtmlHelper helper, string id,string texto)
        {
            string label = $"<label for= '{id}' class = 'sr-only'>{texto}</label> ";

            return MvcHtmlString.Create(label);
        }

        public static MvcHtmlString GerarGraficoChartJs(this HtmlHelper helper,string divId,IHtmlString labels, IHtmlString data, string type,string titulo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("new Chart(document.getElementById('{0}'), ", divId));
                sb.Append("{");
                   sb.Append(string.Format("type: '{0}',", type));
                   sb.Append(string.Format("data: "));
                   sb.Append("{");
                      sb.Append(string.Format("labels: {0},", labels));
                      sb.Append(string.Format("datasets: ["));
                        sb.Append("{");
                           sb.Append(string.Format("label: 'Quantidade',"));
                           sb.Append(string.Format("backgroundColor: [ window.chartColors.red, window.chartColors.orange, window.chartColors.yellow, window.chartColors.green, window.chartColors.blue ],"));
                           sb.Append(string.Format("data: {0}", data));
                        sb.Append("}");
                    sb.Append("]");
                sb.Append("},");
                sb.Append(string.Format("options:"));
                sb.Append("{");
                   sb.Append(string.Format("legend: "));
                       sb.Append("{");
                           sb.Append("display: true");
                       sb.Append("},");
                           sb.Append(string.Format("title: "));
                       sb.Append("{");
                           sb.Append("display: true, text: '" +titulo + "'");
                       sb.Append("},");
                      sb.Append("scales:");
                          sb.Append("{");
                             sb.Append("yAxes: [{");
                             sb.Append("ticks:");
                                 sb.Append("{");
                                      sb.Append("beginAtZero: true");
                                 sb.Append("}");
                             sb.Append("}]");
                          sb.Append("}");
                      sb.Append("}");
                 sb.Append("});");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}