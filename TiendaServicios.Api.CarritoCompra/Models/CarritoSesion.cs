using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.CarritoCompra.Models
{
    public class CarritoSesion
    {
        [Key]
        public int CarritoSesionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }
    }
}
