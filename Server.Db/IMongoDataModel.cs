using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Db
{
    /// <summary>
    /// Interface for all mongo datamodels
    /// </summary>
    public interface IMongoDataModel<T>
    {
        [BsonId]
        ObjectId Id { get; set; }

        [BsonIgnore]
        T This { get; }
    }
}
