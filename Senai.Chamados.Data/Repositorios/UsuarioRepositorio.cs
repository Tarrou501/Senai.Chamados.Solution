using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Domain.Contratos;
using Senai.Chamados.Domain.Entidades;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Chamados.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SenaiChamadosDBContext _contexto;

        public UsuarioRepositorio()
        {
            _contexto = new SenaiChamadosDBContext();
        }

        public bool Alterar(UsuarioDomain domain)
        {
            _contexto.Entry<UsuarioDomain>(domain).State = System.Data.Entity.EntityState.Modified;
            int linhasAlteradas = _contexto.SaveChanges();
            
            if (linhasAlteradas > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Busca o usuário pelo Id
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <param name="includes">Includes para fazer inner join</param>
        /// <returns>Retorna UsuarioDomain</returns>
        public UsuarioDomain BuscarPorId(Guid id, string[] includes = null)
        {
            var query = _contexto.Usuarios.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    // using System.Data.Entity; necessário declarar para query encontrar o método Include
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Excluir usuario no banco
        /// </summary>
        /// <param name="domain">Usuário a ser excluido</param>
        /// <returns> retorna true se o usuário foi excluido e false se não</returns>
        public bool Deletar(UsuarioDomain domain)
        {
            _contexto.Usuarios.Remove(domain);
            int linhasExcluidas = _contexto.SaveChanges();
            if (linhasExcluidas > 0)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        /// <summary>
        /// Insere um novo usuário no banco
        /// </summary>
        /// <param name="domain">Dados do usuário</param>
        /// <returns>Retorna true para usuário cadastrado e false caso não seja cadastrado</returns>
        public bool Inserir(UsuarioDomain domain)
        {
            _contexto.Usuarios.Add(domain);
            int linhasIncluidas = _contexto.SaveChanges();
            if (linhasIncluidas > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Lista todos os usuário do banco
        /// </summary>
        /// <param name="includes">include para fazer Inner Join</param>
        /// <returns>uma lista de usuário</returns>
        public List<UsuarioDomain> List(string[] includes = null)
        {
            var query = _contexto.Usuarios.AsQueryable();
            if(includes != null)
            {
                foreach (var include in includes )
                {
                    // using System.Data.Entity; necessário declarar para query encontrar o método Include
                    query = query.Include(include);                   
                }
                // Equivaliente em Lambda
                //query = includes.Aggregate(query, (current, include)=> current.Include(include));                   
            }
            return query.ToList();
        }

        /// <summary>
        /// Valiadar um usuário no banco
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o usuário caso seja válido</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain objUsuario = _contexto.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            if (objUsuario == null)
                return null;
            else
                return objUsuario;
        }
    }
}
