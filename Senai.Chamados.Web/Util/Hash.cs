using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Senai.Chamados.Web.Util
{
    public class Hash
    {
        public static string GerarHash(string texto)
        {
            // Declaro uma varfiavel do tipo String Builder
            StringBuilder result = new StringBuilder();

            // Declaro uma variavel do tipo SHA256 para encriptografia
            SHA256 sha256 = SHA256Managed.Create();

            // Converto o texto recebido como parametro em bytes
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            
            //Gera um hash de acordo com  a variavel bytes
            byte[] hash = sha256.ComputeHash(bytes);

            // Percorre a
            for (int i= 0;i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }
    }
}