using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Models;

namespace TiendaServicios.Api.CarritoCompra.Persistence
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base (options) { }  
        
        public DbSet<CarritoSesion> CarritoSesion { get; set; }

        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
            
       
    }
}
