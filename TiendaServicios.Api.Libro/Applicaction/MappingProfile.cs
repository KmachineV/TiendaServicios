using AutoMapper;
using TiendaServicios.Api.Libro.Models;

namespace TiendaServicios.Api.Libro.Applicaction
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTO>();
        }
    }
}
