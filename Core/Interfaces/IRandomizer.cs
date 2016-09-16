using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRandomizer
    {
        int GetRandomInt(int from=0,int to=int.MaxValue);

        T GetRandomObject<T>(IList<T> data);

        Guid GetGuid();
    }
}
