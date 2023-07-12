using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaServicios.Api.Autor.Models
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }

        public string Nombre { get; set; }

        public string CentroAcademico { get; set; }

        public DateTime? FechaGrado { get; set; }

        public int AutorLibroId { get; set; }

        public AutorLibro AutorLibro { get; set; }

        public string GradoAcademicoGuid { get; set; }
        


    }
}
