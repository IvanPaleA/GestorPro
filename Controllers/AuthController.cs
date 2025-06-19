using Microsoft.AspNetCore.Mvc;
using GestorPro.Models;
using GestorPro.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GestorPro.Controllers
{
    public class AuthController : Controller
    {
        private readonly GestorProContext _context;

        public AuthController(GestorProContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string idEmpleado, string contraseña)
        {
            // Buscar en la base de datos
            var empleado = _context.Empleados.FirstOrDefault(e =>
                e.IdEmpleado == idEmpleado && e.Contraseña == contraseña);

            if (empleado != null)
            {
                // Guardar en sesión
                HttpContext.Session.SetString("IdEmpleado", empleado.IdEmpleado);
                return RedirectToAction("Index", "Home"); // Cambia "Home" si tienes otro controlador principal
            }

            ViewBag.Error = "ID o contraseña incorrectos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
