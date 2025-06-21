using GestorPro.Data;
using GestorPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorPro.Controllers
{
    public class TurnosController : Controller
    {
        private readonly GestorProContext _context;

        public TurnosController(GestorProContext context)
        {
            _context = context;
        }

        /* public IActionResult Index(bool mostrar = false)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            var turnos = _context.Turnos.ToList();

            ViewBag.MostrarTurnos = mostrar;

            return View(turnos);
        } */

        public IActionResult Index(bool mostrar = false)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            var empleado = _context.Empleados
                .Include(e => e.Turno)
                .FirstOrDefault(e => e.IdEmpleado == idEmpleado);

            if (empleado == null)
                return NotFound();

            var turnos = _context.Turnos.ToList();

            ViewBag.MostrarTurnos = mostrar;
            ViewBag.TurnoActual = empleado.Turno;

            return View(turnos);
        }


        [HttpPost]
        public async Task<IActionResult> SolicitarCambio(int turnoId)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null) return RedirectToAction("Login", "Auth");

            // Validar si ya existe una solicitud pendiente
            var existe = await _context.SolicitudesCambioTurno
                .AnyAsync(s => s.IdEmpleado == idEmpleado && !s.Aprobado);
            if (existe)
            {
                TempData["mensajeError"] = "Ya tienes una solicitud de cambio pendiente.";
                return RedirectToAction("Index");
            }

            var solicitud = new SolicitudCambioTurno
            {
                IdEmpleado = idEmpleado,
                TurnoSolicitadoId = turnoId
            };

            _context.SolicitudesCambioTurno.Add(solicitud);
            await _context.SaveChangesAsync();

            TempData["mensaje"] = "Solicitud enviada correctamente.";
            return RedirectToAction("Index");
        }

    }
}
