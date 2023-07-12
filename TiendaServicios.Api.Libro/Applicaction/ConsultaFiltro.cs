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
            public int LibroMaterialId { get; set; }
        }

        public class Majeador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Majeador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }       

            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libroMaterial = await _contexto.LibreriaMaterial.Where(a => a.LibreriaMaterialId == request.LibroMaterialId).FirstOrDefaultAsync();
                if (libroMaterial != null)
                {
                    var autorDTO = _mapper.Map<LibroMaterialDTO>(libroMaterial);
                    return autorDTO;
                }

                throw new Exception("No existe autor con este id");
            }
        }
    }
}
