using Microsoft.AspNetCore.Mvc;
using GestorPro.Data;
using GestorPro.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace GestorPro.Controllers
{
    public class HorasExtrasController : Controller
    {
        private readonly GestorProContext _context;

        public HorasExtrasController(GestorProContext context)
        {
            _context = context;
        }

        public IActionResult Index(string semana)
        {
            var idEmpleado = HttpContext.Session.GetString("IdEmpleado");
            if (string.IsNullOrEmpty(idEmpleado))
            {
                return RedirectToAction("Login", "Auth");
            }

            if (string.IsNullOrEmpty(semana))
            {
                semana = "1er Sem";
            }

            //Obtener las fechas 
            var fechasSemana = ObtenerRangoFechas(semana);

            //Consultar en la base de datos las horas extras
            var horasExtras = _context.HorasExtras
                .Where(h => h.IdEmpleado == idEmpleado &&
                            h.Fecha >= fechasSemana.Item1 &&
                            h.Fecha <= fechasSemana.Item2)
                .ToList();

            ViewBag.Semana = semana;
            ViewBag.HorasExtras = horasExtras;

            return View();
        }

        private (DateTime, DateTime) ObtenerRangoFechas(string semana)
        {
            var mesActual = DateTime.Today;
            var primerDiaMes = new DateTime(mesActual.Year, mesActual.Month, 1);

            // Rango desemanas
            switch (semana)
            {
                case "2da Sem":
                    return (primerDiaMes.AddDays(7), primerDiaMes.AddDays(13));
                case "3er Sem":
                    return (primerDiaMes.AddDays(14), primerDiaMes.AddDays(20));
                case "4ta Sem":
                    return (primerDiaMes.AddDays(21), primerDiaMes.AddDays(31));
                default:
                    return (primerDiaMes, primerDiaMes.AddDays(6));
            }
        }
    }
}
