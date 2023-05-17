using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Accounts
{
    public class AccountModel
    {
        [BsonId]
        public int Id { get; set; }

        public string AccounName { get; set; }

        public string AccounPass { get; set; }

        public string Email { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsLock { get; set; }
    }
}
