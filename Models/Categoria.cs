using System.ComponentModel.DataAnnotations;

namespace TareasMinimalApi.Models
{
    public class Categoria
    {
        //[Key]
        public Guid id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //Atributos de la relación

        public virtual ICollection<Tarea> Tareas { get; set; } // Esto indica que la propiedad Tareas esta relacionada con la entidad Tarea
    }
}
