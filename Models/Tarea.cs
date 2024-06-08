using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareasMinimalApi.Models
{
    public class Tarea
    {

        [Key] // Esto indica que la propiedad TareaId es la clave primaria de la entidad
        public Guid TareaId { get; set; }
        //Atributos de la relación con Categoria

        [ForeignKey("Categoria")] // Esto indica que la propiedad CategoriaId es una clave foránea que apunta a la entidad Categoria
        public Guid CategoriaId { get; set; }

        [Required, MaxLength(150)] // Esto indica que la propiedad Nombre es requerida y tiene una longitud máxima de 150 caracteres
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }

        //Atributos de la relación con Usuario
        
        public virtual Categoria Categoria { get; set; } // Esto indica que la propiedad Categoria esta relacionada con la entidad Categoria

        [NotMapped] // Esto indica que la propiedad Resumen no se mapea a la base de datos
        public string Resumen { get; set; }
    }

    public enum Prioridad // enum solo es un tipo de dato que puede tener uno de los valores de la lista
    {
        Baja,
        Media,
        Alta
    }

}
