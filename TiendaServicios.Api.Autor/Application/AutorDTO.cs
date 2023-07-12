using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Application
{
    public class AutorDTO
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}
