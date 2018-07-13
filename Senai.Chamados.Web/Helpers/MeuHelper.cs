using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senai.Chamados.Web.Helpers
{
    public class MeuHelper
    {
        public static string DireitosReservados()
        {
            return "®" + DateTime.Now.Year + " -Senaim- Todos os direitos reservados";
        }

        public static string BoasVindas()
        {
            return "Seja bem vindos, ";
        }
    }
}