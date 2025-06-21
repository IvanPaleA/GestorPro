using Microsoft.AspNetCore.Mvc;
using GestorPro.Models;
using GestorPro.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace GestorPro.Controllers
{
    public class PanelAdminController : Controller
    {
        private readonly GestorProContext _context;

        public PanelAdminController(GestorProContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Administrador")
            {
                TempData["mensajeError"] = "No tienes permiso para acceder a esta función.";
                return RedirectToAction("Index", "Home");
            }

            var empleados = _context.Empleados.ToList();
            return View(empleados);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Administrador")
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Empleado nuevo)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(nuevo);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Usuario registrado correctamente.";
                return RedirectToAction("Index");
            }
            return View(nuevo);

        }

        // GET: PanelAdmin/Editar/id
        public IActionResult Editar(string id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: PanelAdmin/Editar
        [HttpPost]
        public IActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                _context.SaveChanges();
                TempData["mensaje"] = "Empleado actualizado correctamente.";
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: PanelAdmin/Eliminar/id
        public IActionResult Eliminar(string id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: PanelAdmin/EliminarConfirmado
        [HttpPost, ActionName("EliminarConfirmado")]
        public IActionResult EliminarConfirmado(string id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
                TempData["mensaje"] = "Empleado eliminado correctamente.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Pagos(string idEmpleado)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == idEmpleado);
            if (empleado == null) return NotFound();

            var pagos = _context.RegistrosPago
                .Where(p => p.EmpleadoId == idEmpleado)
                .OrderByDescending(p => p.Periodo)
                .ToList();

            ViewBag.Empleado = empleado;
            return View(pagos);
        }

        [HttpPost]
        public IActionResult EditarPago(RegistroPago pago)
        {
            Console.WriteLine($"Editando pago {pago.Id} - {pago.Periodo} - {pago.PagoBase} - {pago.PagoExtra}");
            if (ModelState.IsValid)
            {
                var existente = _context.RegistrosPago.FirstOrDefault(p => p.Id == pago.Id);
                if (existente != null)
                {
                    existente.Periodo = pago.Periodo;
                    existente.PagoBase = pago.PagoBase;
                    existente.PagoExtra = pago.PagoExtra;
                    existente.Total = pago.PagoBase + pago.PagoExtra;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Pagos", new { idEmpleado = pago.EmpleadoId });
        }


        [HttpPost]
        public IActionResult AgregarPago(string idEmpleado)
        {
            var nuevo = new RegistroPago
            {
                EmpleadoId = idEmpleado,
                Periodo = "Nueva Quincena",
                PagoBase = 4000,
                PagoExtra = 0,
                Total = 4000
            };
            _context.RegistrosPago.Add(nuevo);
            _context.SaveChanges();

            return RedirectToAction("Pagos", new { idEmpleado = idEmpleado });
        }

        [HttpGet]
        public IActionResult HorasExtras(string idEmpleado)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == idEmpleado);
            if (empleado == null) return NotFound();

            var modelo = new HorasExtra
            {
                IdEmpleado = empleado.IdEmpleado,
                Fecha = DateTime.Now
            };

            ViewBag.NombreEmpleado = empleado.IdEmpleado;
            return View(modelo);
        }

        [HttpPost]
        public IActionResult HorasExtras(HorasExtra modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.Monto = modelo.CantidadHoras * 50;
                _context.HorasExtras.Add(modelo);
                _context.SaveChanges();

                TempData["mensaje"] = "Horas extra registradas correctamente.";
                return RedirectToAction("Index");
            }

            ViewBag.NombreEmpleado = modelo.IdEmpleado;
            return View(modelo);
        }

        public IActionResult SolicitudesTurno()
        {
            var solicitudes = _context.SolicitudesCambioTurno
                .Include(s => s.Empleado)
                .Include(s => s.TurnoSolicitado)
                .Where(s => !s.Aprobado)
                .ToList();

            return View(solicitudes);
        }

        [HttpPost]
        public async Task<IActionResult> AprobarSolicitud(int id)
        {
            var solicitud = await _context.SolicitudesCambioTurno
                .Include(s => s.Empleado)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitud != null)
            {
                solicitud.Aprobado = true;
                solicitud.Empleado.TurnoId = solicitud.TurnoSolicitadoId;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("SolicitudesTurno");
        }
        
        public IActionResult VerTurnos()
        {
            var turnos = _context.Turnos
                .Include(t => t.Empleados)
                .ToList();

            return View(turnos);
        }

    }
}
