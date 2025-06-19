using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPro.Models
{
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdEmpleado { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        public TimeSpan? HoraEntrada { get; set; }

        [Required]
        public string Estado { get; set; } = "";

        [Required]
        public string Dia { get; set; } = "";

        [ForeignKey("IdEmpleado")]
        public Empleado? Empleado { get; set; }
    }
}
