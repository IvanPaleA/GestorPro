using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPro.Models
{
    public class HorasExtra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdEmpleado { get; set; } = string.Empty;

        [ForeignKey("IdEmpleado")]
        public Empleado? Empleado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int CantidadHoras { get; set; }

        [Required]
        public decimal Monto { get; set; }
    }
}
