using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Models;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class Consulta
    {
           
        public class ListaAutor : IRequest<List<AutorDTO>> {        }


        public class Manejador : IRequestHandler<ListaAutor, List<AutorDTO>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<AutorDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();

                var autoresDTO = _mapper.Map<List<AutorLibro>, List<AutorDTO>> (autores);

                return autoresDTO;
            }
        }
    }
}
