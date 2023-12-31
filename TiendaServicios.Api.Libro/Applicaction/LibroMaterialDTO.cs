﻿using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Libro.Applicaction
{
    public class LibroMaterialDTO
    {

        public Guid LibreriaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibroGuid { get; set; }
    }
}
