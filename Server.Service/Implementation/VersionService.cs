using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Server.Core;
using Server.Db;
using Server.Db.Repositories.Mongo;
using Version = Server.Service.DataModel.Version;

namespace Server.Service.Implementation
{
    /// <summary>
    /// Service for work with server versions  
    /// </summary>
    public sealed class VersionService : MongoRepository<Version>, IVersionService
    {
        /// <summary>
        /// .ctor to create CRUD operation to mongo DB with connection string to ServerSetting 
        /// </summary>
        public VersionService() : base(GlobalFacade.Settings.ServerSettingDbConnection)
        {

        }

        /// <summary>
        /// Method to get all version from Database
        /// </summary>
        /// <returns>All Versions</returns>
        public async Task<IList<dynamic>> GetAllVersions()
        {
            var result = new List<dynamic>();
            foreach (var version in GetAll())
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

        public async Task<bool> CheckVersion(string version)
        {
            //var vers = await ProviderAsync.GetFilteredAsync<Version>(new BsonDocument() { { "Vers", new BsonRegularExpression($"/{version}/") } });

            //return vers.Count > 0;

            return true;
        }
    }
}
