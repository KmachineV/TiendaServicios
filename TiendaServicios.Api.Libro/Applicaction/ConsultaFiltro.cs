using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Applicaction
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDTO>
        {
            public Guid LibroMaterialId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }       

            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libroMaterial = await _contexto.LibreriaMaterial.Where(a => a.LibreriaMaterialId == request.LibroMaterialId).FirstOrDefaultAsync();
                if (libroMaterial != null)
                {
                    var libroMaterialDTO = _mapper.Map<LibroMaterialDTO>(libroMaterial);
                    return libroMaterialDTO;
                }

                throw new Exception("No existe autor con este id");
            }
        }
    }
}
