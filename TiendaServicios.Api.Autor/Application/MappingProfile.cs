using AutoMapper;
using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDTO>();
        }
    }
}
