namespace GestorPro.Models
{
    public class AsistenciaExtendida
    {
        public string Dia { get; set; } = "";
        public DateTime Fecha { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public string Estado { get; set; } = "";
    }
}
