using Microsoft.AspNetCore.Mvc;

namespace GestorPro.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
