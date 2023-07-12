using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Models;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public string AutorGuid { get; set; }
        }

        public class Majeador : IRequestHandler<AutorUnico, AutorDTO>
        {
            private readonly ContextoAutor _contexto;
            private readonly  IMapper _mapper;

            public Majeador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
             }
            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro.Where(a => a.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();


                if (autor != null)
                {

                    var autorDTO = _mapper.Map<AutorDTO>(autor);
                    return autorDTO;
                }

                throw new Exception("No existe autor con este id");
            }
        }
    }
}
