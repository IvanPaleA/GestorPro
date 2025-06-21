using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPro.Models
{
    public class SolicitudCambioTurno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdEmpleado { get; set; } = string.Empty;

        [ForeignKey("IdEmpleado")]
        public Empleado Empleado { get; set; } = null!;

        [Required]
        public int TurnoSolicitadoId { get; set; }

        [ForeignKey("TurnoSolicitadoId")]
        public Turno TurnoSolicitado { get; set; } = null!;

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public bool Aprobado { get; set; } = false;
    }
}
