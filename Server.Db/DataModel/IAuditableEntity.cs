using System;

namespace Server.Db.DataModel
{
    public interface IAuditableEntity<T> : IEntity<T>
    {
        /// <summary>
        /// create date
        /// </summary>
        DateTime CreatedOn { get; }

        /// <summary>
        /// modify date
        /// </summary>
        DateTime ModifiedOn { get; }
    }
}
