using FluentValidation;
using MediatR;
using TiendaServicios.Api.Libro.Models;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Applicaction
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }

            public Guid? AutorLibroGuid { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibroGuid).NotEmpty();
            }
        }



        public class Manejador : IRequestHandler<Ejecuta>
        {

            private readonly ContextoLibreria _contexto;

            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libreriaMaterial = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibroGuid = request.AutorLibroGuid,
                };
                _contexto.LibreriaMaterial.Add(libreriaMaterial);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                    return Unit.Value;


                throw new Exception("No se pudo insertar el autor del libro");


            }
        }
    }
}
