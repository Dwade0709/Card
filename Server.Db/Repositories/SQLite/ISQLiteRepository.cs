using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Db.DataModel;

namespace Server.Db.Repositories.SQLite
{
    public interface ISqLiteRepository<T> : ICrud<T> where T : BaseEntity
    {
        /// <summary>
        /// Database context
        /// </summary>
        DatabaseContext Context { get; }

        /// <summary>
        /// Entities dbset
        /// </summary>
        DbSet<T> Entities { get; }

        /// <summary>
        /// Error message if exist
        /// </summary>
        string ErrorText { get; set; }

        /// <summary>
        /// update an entity with updated fields
        /// </summary>
        /// <param name="entity">entity</param>
        bool Update(T entity);

        /// <summary>
        /// update an entity with updated fields
        /// </summary>
        /// <param name="entity">entity</param>
        Task<bool> UpdateAsync(T entity);
    }
}
