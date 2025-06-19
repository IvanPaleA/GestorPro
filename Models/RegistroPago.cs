using System.ComponentModel.DataAnnotations;

namespace GestorPro.Models
{
    public class RegistroPago
    {
        [Key]
        public int Id { get; set; }

        public string EmpleadoId { get; set; } = string.Empty;

        public string Periodo { get; set; } = string.Empty;

        public decimal PagoBase { get; set; }

        public decimal PagoExtra { get; set; }

        public decimal Total { get; set; }

        public Empleado Empleado { get; set; } = null!;
    }
}
