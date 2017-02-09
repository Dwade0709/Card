using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db;
using Server.Service.DataModel;

namespace Server.Service
{
    public interface IVersionService : ICrud<Version>
    {
        Task<IList<dynamic>> GetAllVersions();
    }
}
