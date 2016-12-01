using Microsoft.AspNetCore.Mvc;

namespace Server.Admin.Controllers
{
    public class ServersController : Controller
    {
        public IActionResult Servers()
        {
            ViewBag.Title = "Servers";
            return View();
        }
    }
}
