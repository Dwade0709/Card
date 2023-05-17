using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db;
using Server.Db.Repositories;
using Server.Service.DataModel;

namespace Server.Service
{
    public interface IVersionService : ICrud<Version>
    {
        Task<IList<dynamic>> GetAllVersions();

        Task<bool> CheckVersion(string version);
    }
}
