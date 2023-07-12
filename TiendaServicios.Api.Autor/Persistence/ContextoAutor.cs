using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options ) : base( options ) { }  
        
        public DbSet<AutorLibro> AutorLibro { get; set; }

        public DbSet<GradoAcademico> GradoAcademico { get; set; }

    }
}
