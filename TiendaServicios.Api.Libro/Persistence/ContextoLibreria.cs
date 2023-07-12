using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Models;

namespace TiendaServicios.Api.Libro.Persistence
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)   {}

        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
