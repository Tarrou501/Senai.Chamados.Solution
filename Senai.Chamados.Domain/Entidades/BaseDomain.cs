using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key] // Se não for colado [key], por default é id, não é ncessário se tenho a primarykey com nome de Id
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime  DataAlteracao { get; set; }
    }
}
