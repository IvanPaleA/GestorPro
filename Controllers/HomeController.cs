using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GestorPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            return View();
            
        }

        public IActionResult IniciarJornada()
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (idEmpleado == null)
                return RedirectToAction("Login", "Auth");

            ViewBag.HoraInicio = DateTime.Now.ToString("HH:mm:ss");
            return View();
            
        }
    }
}
