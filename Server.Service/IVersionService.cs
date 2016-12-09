﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Db;
using Server.Service.DataModel;

namespace Server.Service
{
    public interface IVersionService : ICrud<Version>
    {
        Task<IList<Version>> GetAllVersions();

        void CreateOrUpdateVersion(Version data);
    }
}
