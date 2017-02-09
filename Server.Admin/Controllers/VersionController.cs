using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using Server.Service;
using Server.Db.DataModel;

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
                Id = new ObjectId(data.id.ToString()),
                Vers = data.Vers,
                StartedTime = Convert.ToDateTime(data.StartedTime.ToString()),

                State = Enum.Parse(typeof(EVersionState), data.State.ToString())
            };
            version.IsActual = data.IsActual != null ? Convert.ToBoolean(data.IsActual.ToString()) : false;
            _versionService.CreateOrUpdateAsync(version);
        }

        [HttpPost]
        public void DeleteVersion([FromBody]dynamic data)
        {
            _versionService.RemoveAsync(data.id);
        }
    }
}