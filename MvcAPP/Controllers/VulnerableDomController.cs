using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class VulnerableDOMController : Controller
    {
        [HttpGet]
        public IActionResult Message()
        {
            return View();
        }
    }
}
