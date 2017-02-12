namespace Server.Db.DataModel
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
