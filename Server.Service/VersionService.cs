using Server.Db;
using Server.Service.DataModel;

namespace Server.Service
{
    internal class VersionService : CrudDb<Version, IMongoDbProvider>, IVersionService
    {

    }
}
