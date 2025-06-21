
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPro.Models
{
    public class Empleado
    {
        [Key]
        public string IdEmpleado { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;

        public int? TurnoId { get; set; }

        [ForeignKey("TurnoId")]
        public Turno? Turno { get; set; }

        public ICollection<Jornada> Jornadas { get; set; } = new List<Jornada>();

        public string Rol { get; set; } = "Empleado"; // Valor por defecto


    }
}
