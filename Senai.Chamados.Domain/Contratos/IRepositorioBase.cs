using System;
using System.Collections.Generic;

namespace Senai.Chamados.Domain.Contratos
{
    //Repositório genérico
    public interface IRepositorioBase<TDomain> where TDomain :class
    {
        TDomain BuscarPorId(Guid id, string[] includes = null);
        List<TDomain> Listar(string[] includes = null);
        bool Inserir(TDomain domain);
        bool Alterar(TDomain domain);
        bool Deletar(TDomain domain);
    }
}
