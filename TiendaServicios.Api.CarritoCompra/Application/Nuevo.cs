using MediatR;
using TiendaServicios.Api.CarritoCompra.Models;
using TiendaServicios.Api.CarritoCompra.Persistence;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }

            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;

            public Manejador(CarritoContexto contexto)
            {
                    _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                     FechaCreacion = request.FechaCreacionSesion
                };

                _contexto.CarritoSesion.Add(carritoSesion);
                var value = await _contexto.SaveChangesAsync();

                if(value == 0)
                {
                    throw new Exception("Error en la creacion del carrito de compras");
                }

                int id = carritoSesion.CarritoSesionId;
                List<CarritoSesionDetalle> listPivotCarritoSesion = new List<CarritoSesionDetalle>();
                foreach(var obj in request.ProductoLista){
                    var detalle = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj,
                    };
                    listPivotCarritoSesion.Add(detalle);
                }
                await _contexto.CarritoSesionDetalle.AddRangeAsync(listPivotCarritoSesion);
                value = await _contexto.SaveChangesAsync();
                if(value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el detalle del Carrito de compras");
            }
        }
    }
}
