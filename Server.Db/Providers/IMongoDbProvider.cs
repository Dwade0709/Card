namespace Server.Db.Providers
{
    public interface IMongoDbProvider : IDbProvider
    {
        void CreateOrUpdate<T>(IMongoDataModel<T> obj) where T : IMongoDataModel<T>;

        bool Remove<T>(IMongoDataModel<T> obj) where T : IMongoDataModel<T>;

        void CreateOrUpdateAsync<T>(IMongoDataModel<T> obj) where T : IMongoDataModel<T>;

        void RemoveAsync<T>(IMongoDataModel<T> obj) where T : IMongoDataModel<T>;
    }
}
