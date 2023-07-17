using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Applicaction;
using TiendaServicios.Api.Libro.Models;

namespace TiendaServicios.Api.Libro.Tests
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTO>();
        }
    }
}
