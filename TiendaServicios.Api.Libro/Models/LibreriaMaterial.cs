using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Libro.Models
{
    public class LibreriaMaterial
    {
        [Key]
        public Guid LibreriaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibroGuid { get; set; }


    }
}
