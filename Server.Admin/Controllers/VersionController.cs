using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Server.Service;

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

        public async Task<JsonResult> Versions()
        {
            var all = await _versionService.GetAllVersions();
            return new JsonResult(all);
        }

        [HttpPost]
        public void SaveVersion([FromBody]dynamic data)
        {
            var version = new Server.Service.DataModel.Version
            {
                Vers = data.Vers,
                StartedTime = Convert.ToDateTime(data.StartedTime.ToString()),
                State = Enum.Parse(typeof(EVersionState), data.State.ToString()),
                IsActual = data.IsActual != null ? Convert.ToBoolean(data.IsActual.ToString()) : false
            };
            _versionService.InsertAsync(version);
        }

        [HttpPost]
        public void DeleteVersion([FromBody]dynamic data)
        {
            _versionService.Delete(data.id.ToString());
        }
    }
}