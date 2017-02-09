using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Server.Core;
using Server.Db;
using Server.Db.Providers;
using Version = Server.Service.DataModel.Version;

namespace Server.Service.Implementation
{
    /// <summary>
    /// Service for work with server versions  
    /// </summary>
    public sealed class VersionService : CrudDb<Version>, IVersionService
    {
        /// <summary>
        /// .ctor to create CRUD operation to mongo DB with connection string to ServerSetting 
        /// </summary>
        public VersionService() : base(EDataBase.MogoDataBase, GlobalFacade.Settings.ServerSettingDbConnection)
        {

        }

        /// <summary>
        /// Method to get all version from Database
        /// </summary>
        /// <returns>All Versions</returns>
        public async Task<IList<dynamic>> GetAllVersions()
        {
            var result = new List<dynamic>();
            foreach (var version in await GetAllAsync())
            {
                dynamic obj = new ExpandoObject();
                obj.id = version.Id.ToString();
                obj.State = version.State.ToString();
                obj.IsActual = version.IsActual;
                obj.StartedTime = version.StartedTime.ToString("dd.MM.yyy HH:mm:ss");
                obj.Vers = version.Vers;
                result.Add(obj);
            }
            return result;
        }
    }
}
