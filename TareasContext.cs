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


        //Con el método OnModelCreating se especifica el modelo de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //especificar el modelo usando fluent api
            modelBuilder.Entity<Categoria>(Categoria =>
            {
                Categoria.ToTable("Categoria"); //especificar el nombre de la tabla
                //especificar la clave primaria
                Categoria.HasKey(c => c.id);
                //especificar que el nombre es requerido y tiene una longitud máxima de 150 caracteres
                Categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                //especificar que la descripción tiene una longitud máxima de 500 caracteres
                Categoria.Property(c => c.Descripcion).HasMaxLength(500);
            });

            modelBuilder.Entity<Tarea>(Tarea =>
            {
                Tarea.ToTable("Tarea"); //especificar el nombre de la tabla
                //especificar la clave primaria
                Tarea.HasKey(t => t.TareaId);
                //especificar que el nombre es requerido y tiene una longitud máxima de 150 caracteres
                Tarea.Property(t => t.Nombre).IsRequired().HasMaxLength(150);
                //especificar que la descripción tiene una longitud máxima de 500 caracteres
                Tarea.Property(t => t.Descripcion).HasMaxLength(500);
                //especificar que la propiedad PrioridadTarea es de tipo Prioridad
                Tarea.Property(t => t.PrioridadTarea).HasConversion<string>();
                //especificar que la propiedad FechaCreacion es la fecha y hora actual
                Tarea.Property(t => t.FechaCreacion).HasDefaultValueSql("GETDATE()");
                //especificar que la propiedad Resumen no se mapea a la base de datos
                Tarea.Ignore(t => t.Resumen);
                //especificar la relación con la entidad Categoria
                Tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
            });
        }



        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
    
}
