using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Models;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Applicaction
{
    public class Consulta
    {
        public class ListaLibroMaterial : IRequest<List<LibroMaterialDTO>> { }    


        public class Manejador : IRequestHandler<ListaLibroMaterial, List<LibroMaterialDTO>>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<LibroMaterialDTO>> Handle(ListaLibroMaterial request, CancellationToken cancellationToken)
            {
                var listaLibroMaterial = await _contexto.LibreriaMaterial.ToListAsync();

                var autoresDTO = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDTO>>(listaLibroMaterial);

                return autoresDTO;
            }
        }
    }
}
