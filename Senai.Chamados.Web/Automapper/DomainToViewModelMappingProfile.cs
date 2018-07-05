using AutoMapper;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels;
using Senai.Chamados.Web.ViewModels.Chamados;
using Senai.Chamados.Web.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senai.Chamados.Web.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap(typeof(UsuarioDomain),typeof(CadastrarUsuarioViewModel));
            Mapper.CreateMap(typeof(UsuarioDomain), typeof(UsuarioViewModel));
            Mapper.CreateMap(typeof(ChamadoDomain), typeof(ChamadoViewModel));
        }
    }
}