using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using Server.Service;
using Version = Server.Service.DataModel.Version;

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
            return View();
        }

        public JsonResult Versions()
        {
            return new JsonResult(_versionService.GetAllVersions().Result);
        }

        [HttpPost]
        public void SaveVersion([FromBody]Version data)
        {
            _versionService.CreateOrUpdateVersion(data);
        }

        [HttpPost]
        public void DeleteVersion([FromBody]Version data)
        {
            _versionService.RemoveAsync(data);
        }
    }
}