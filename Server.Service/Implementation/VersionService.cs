using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Core;
using Server.Db;
using Server.Db.Providers;
using Server.Service.DataModel;

namespace Server.Service.Implementation
{
    /// <summary>
    /// Service for work with server versions  
    /// </summary>
    internal sealed class VersionService : CrudDb<Version, IMongoDbProvider>, IVersionService
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
        public async Task<IList<Version>> GetAllVersions()
        {
            return await GetAllAsync();
        }
    }
}
