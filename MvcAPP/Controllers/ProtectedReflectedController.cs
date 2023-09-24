using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class ProtectedReflectedController : Controller
    {
        [HttpGet]
        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View();
        }
    }
}
