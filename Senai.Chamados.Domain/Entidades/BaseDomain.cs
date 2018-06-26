using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Entidades
{
    /// <summary>
    /// Dominio basendo sistema
    /// </summary>
    public abstract class  BaseDomain
    {

        public Guid id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime  DataAlteracao { get; set; }
    }
}
