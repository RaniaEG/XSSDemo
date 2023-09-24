using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcApp.Controllers
{
    public class ProtectedDOMController : Controller
    {
        [HttpGet]
        public IActionResult Message(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                ViewBag.EncodedMsg = HtmlEncoder.Default.Encode(msg);
            }
            else
            {
                ViewBag.EncodedMsg = string.Empty;
            }

            return View();
        }
    }
}
