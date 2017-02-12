namespace Server.Db.DataModel
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
