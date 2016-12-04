using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Db
{
    public interface ICrud<T>
    {
        void Create(T obj);

        void CreateOrUpdate(T obj);

        bool Remove(T obj);

        bool Remove(object objectId);

        void CreateAsync(T obj);

        void CreateOrUpdateAsync(T obj);

        bool RemoveAsync(T obj);

        bool RemoveAsync(object objectId);

        IList<T> GetAll();

        Task<IList<T>> GetAllAsync();

        IList<T> GetFiltered(object filter);

        Task<IList<T>> GetFilteredAsync(object filter);
    }
}
