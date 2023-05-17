using System;

namespace Server.Db.DataModel
{
    /// <summary>
    /// Entity wrapper for non-edittable models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T> : IAuditableEntity<T>, IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; }
        public DateTime ModifiedOn { get; }
    }
}
