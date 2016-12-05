using MongoDB.Bson;

namespace Server.Db
{
    /// <summary>
    /// Interface for all mongo datamodels
    /// </summary>
    public interface IMongoDataModel
    {
        ObjectId Id { get; set; }
    }
}
