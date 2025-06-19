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

        public IActionResult Index(bool mostrar = false)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            var turnos = _context.Turnos.ToList();

            ViewBag.MostrarTurnos = mostrar;

            return View(turnos);
        }

        [HttpPost]
        public async Task<IActionResult> CambiarTurno(int turnoId)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == idEmpleado);
            if (empleado != null)
            {
                empleado.TurnoId = turnoId;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
