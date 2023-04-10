using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDeEnlace.ModeloDeDatos
{
    [Table("Profesores")]
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
    }
}