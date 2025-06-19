using Microsoft.EntityFrameworkCore;
using GestorPro.Models;

namespace GestorPro.Data
{
    public class GestorProContext : DbContext
    {
        public GestorProContext(DbContextOptions<GestorProContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<HorasExtra> HorasExtras { get; set; }
        public DbSet<RegistroPago> RegistroPagos { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}
