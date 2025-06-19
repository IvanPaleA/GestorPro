using GestorPro.Data;
using GestorPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorPro.Controllers
{
    public class RegistroController : Controller
    {
        private readonly GestorProContext _context;

        public RegistroController(GestorProContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? periodo)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            //Obtener registros
            var query = _context.RegistroPagos
                        .Where(r => r.EmpleadoId == idEmpleado);

            if (!string.IsNullOrEmpty(periodo))
            {
                query = query.Where(r => r.Periodo == periodo);
            }
            else
            {
                query = query.OrderByDescending(r => r.Id).Take(5);
            }

            var registros = await query.OrderByDescending(r => r.Id).ToListAsync();

            var periodosDisponibles = await _context.RegistroPagos
                                        .Where(r => r.EmpleadoId == idEmpleado)
                                        .Select(r => r.Periodo)
                                        .Distinct()
                                        .OrderByDescending(p => p)
                                        .ToListAsync();

            ViewBag.Periodos = periodosDisponibles;
            ViewBag.PeriodoSeleccionado = periodo;

            return View(registros);
        }
    }
}
