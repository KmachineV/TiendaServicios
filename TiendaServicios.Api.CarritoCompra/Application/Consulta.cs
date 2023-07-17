using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteService;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDTO>{
            public int CarritoSesionId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibroService _libroService;

            public Manejador(CarritoContexto contexto,  ILibroService libroService)
            {
                _contexto = contexto;
                _libroService = libroService;

            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _contexto.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);

                var carritoSesionDetalle = _contexto.CarritoSesionDetalle.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToList();

                List<CarritoDetalleDTO> carritoDetallesDTOList = new List<CarritoDetalleDTO>();
                foreach(var libro in carritoSesionDetalle) {
                    var response = await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));
                    if (response.resultado)
                    {
                        var objetoLibro = response.libro;
                        var carritoDetalle = new CarritoDetalleDTO
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        carritoDetallesDTOList.Add(carritoDetalle);

                    }
                }

                var carritoSesionDTO = new CarritoDTO
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = carritoDetallesDTOList
                };

                return carritoSesionDTO;
            }
        }
    }
}
