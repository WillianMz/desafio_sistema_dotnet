using AutoMapper;
using Desafio.API.Models;
using Desafio.API.ViewModels;

namespace Desafio.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
