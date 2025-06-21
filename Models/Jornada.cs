using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPro.Models
{
    public class Jornada
    {
        public int Id { get; set; }

        [ForeignKey("Empleado")]
        public string IdEmpleado { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public DateTime? HoraInicio { get; set; }

        public DateTime? HoraFin { get; set; }

        public Empleado Empleado { get; set; } = default!;
    }
}
