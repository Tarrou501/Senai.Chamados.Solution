using Senai.Chamados.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Contratos
{
    public interface IChamadoRepositorio:IDisposable,IRepositorioBase<ChamadoDomain>
    {
        
        List<ChamadoDomain> Listar(Guid idUsuario,string [] includes =null);
    }
}
