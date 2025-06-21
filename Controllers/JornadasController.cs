using Microsoft.AspNetCore.Mvc;
using GestorPro.Models;
using GestorPro.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace GestorPro.Controllers
{
    public class JornadasController : Controller
    {
        private readonly GestorProContext _context;

        public JornadasController(GestorProContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");

            if (string.IsNullOrEmpty(idEmpleado))
            {
                TempData["mensaje"] = "Error: No se encontró el ID del empleado en sesión.";
                return RedirectToAction("Login", "Auth");
            }

            var jornadas = await _context.Jornadas
                .Where(j => j.IdEmpleado == idEmpleado)
                .Include(j => j.Empleado)
                .ToListAsync();

            return View(jornadas);
        }


/*         [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        } */

        [HttpPost]
        public async Task<IActionResult> Registrar()
        {
            // Obtener el IdEmpleado desde la sesión
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");

            if (string.IsNullOrEmpty(idEmpleado))
            {
                TempData["mensaje"] = "Error: No se encontró el ID del empleado en sesión.";
                return RedirectToAction("Index");
            }

            // Validar si ya tiene una jornada activa sin cerrar
            var jornadaActiva = await _context.Jornadas
                .FirstOrDefaultAsync(j => j.IdEmpleado == idEmpleado && j.HoraFin == null);

            if (jornadaActiva != null)
            {
                TempData["mensaje"] = "Ya tienes una jornada activa que no ha sido finalizada.";
                return RedirectToAction("Index");
            }

            var nuevaJornada = new Jornada
            {
                IdEmpleado = idEmpleado,
                Fecha = DateTime.Now,
                HoraInicio = DateTime.Now
            };

            _context.Jornadas.Add(nuevaJornada);

            // Crear registro de asistencia
            var nuevaAsistencia = new Asistencia
            {
                IdEmpleado = idEmpleado,
                Fecha = DateTime.Now.Date,
                HoraEntrada = DateTime.Now.TimeOfDay,
                Dia = DateTime.Now.ToString("dddd"),
                Estado = "Presente"
            };

            _context.Asistencias.Add(nuevaAsistencia);


            await _context.SaveChangesAsync();

            TempData["mensaje"] = "Jornada registrada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Finalizar(int id)
        {
            var jornada = await _context.Jornadas.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }

            jornada.HoraFin = DateTime.Now;
            await _context.SaveChangesAsync();

            TempData["mensaje"] = "Jornada finalizada correctamente.";
            return RedirectToAction("Index");
        }
    }
}
