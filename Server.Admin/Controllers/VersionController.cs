using Microsoft.AspNetCore.Mvc;
using Server.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Admin.Controllers
{
    public class VersionController : Controller
    {
        private readonly IVersionService _versionService;

        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }

        public IActionResult Version()
        {
            return View(_versionService.GetAllVersions().Result);
        }
    }
}
