using System.ComponentModel.DataAnnotations;

namespace GestorPro.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Horario { get; set; } = string.Empty;
    }
}
