using Microsoft.AspNetCore.Mvc;
using Server.Service;
using Server.Service.DataModel;

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

        public JsonResult Versions()
        {
            return new JsonResult(_versionService.GetAllVersions());
        }

        [HttpPost]
        public void SaveVersionFromBody([FromBody] Version data)
        {
            //return new JsonResult(_versionService.GetAllVersions());
        }

        [HttpPost]
        public void SaveVersion(Version data)
        {
            //return new JsonResult(_versionService.GetAllVersions());
        }
    }
}