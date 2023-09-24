using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class VulnerableReflectedController : Controller
    {
        [HttpGet]
        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View();
        }
    }
}
