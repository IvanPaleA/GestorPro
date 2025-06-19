
using Microsoft.AspNetCore.Mvc;
using GestorPro.Data;
using GestorPro.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorPro.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly GestorProContext _context;

        public AsistenciaController(GestorProContext context)
        {
            _context = context;
        }

        public IActionResult Index(string semana = "1er Sem")
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            // Obtener asistencias desde la base de datos
            var asistencias = _context.Asistencias
                .Where(a => a.IdEmpleado == idEmpleado)
                .ToList();

            // Diccionario de semanas con fechas
            var semanas = new Dictionary<string, (DateTime inicio, DateTime fin)>
            {
                ["1er Sem"] = (new DateTime(2025, 6, 2), new DateTime(2025, 6, 6)),
                ["2da Sem"] = (new DateTime(2025, 6, 9), new DateTime(2025, 6, 13)),
                ["3er Sem"] = (new DateTime(2025, 6, 16), new DateTime(2025, 6, 20)),
                ["4ta Sem"] = (new DateTime(2025, 6, 23), new DateTime(2025, 6, 27))
            };

            var semanaSeleccionada = semanas.ContainsKey(semana) ? semanas[semana] : semanas["1er Sem"];

            var asistenciasSeleccionadas = asistencias
                .Where(a => a.Fecha >= semanaSeleccionada.inicio && a.Fecha <= semanaSeleccionada.fin)
                .Select(a => new AsistenciaExtendida
                {
                    Dia = a.Dia,
                    Fecha = a.Fecha,
                    HoraEntrada = a.HoraEntrada,
                    Estado = a.Estado
                }).ToList();

            ViewBag.SemanaSeleccionada = semana;
            return View(asistenciasSeleccionadas);
        }
    }
}
