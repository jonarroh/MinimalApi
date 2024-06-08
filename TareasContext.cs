using Microsoft.EntityFrameworkCore;
using TareasMinimalApi.Models;

namespace TareasMinimalApi
{

    //TIENES QUE AGREGAR ESTE CODIGO
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
    
}
