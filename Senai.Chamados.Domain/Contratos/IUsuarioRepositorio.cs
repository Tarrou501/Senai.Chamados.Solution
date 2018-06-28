using Senai.Chamados.Domain.Entidades;
using System;


namespace Senai.Chamados.Domain.Contratos
{
    public interface IUsuarioRepositorio:IDisposable,IRepositorioBase<UsuarioDomain>
    {
        UsuarioDomain Login(string email, string senha);
    }
}
