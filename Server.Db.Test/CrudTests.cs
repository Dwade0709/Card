using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using MongoDB.Bson;
using Xunit;
using Server.Db.DataModel;
using Server.Db.Repositories;
using Server.Db.Repositories.Mongo;

namespace Server.Db.Test
{
    public class CrudTests
    {
        private readonly ICrud<TestClass> _crudService;

        public CrudTests()
        {
            _crudService = new MongoRepository<TestClass>("mongodb://localhost:27017");
        }

        [Fact]
        public void CrudOperation()
        {
            //((IMongoDbProvider)_crudService.Provider).Client.DropDatabase("Test");
            //((IMongoDbProvider)_crudService.Provider).Client.GetDatabase("Test");
            //var data = new TestClass { Text = "test data" };
            //Assert.True(_crudService.GetAll().Count == 0);
            //_crudService.Create(data);
            //Assert.True(_crudService.GetAll().Count > 0);
            //data.Text = "Updated text";
            //_crudService.CreateOrUpdate(data);
            //Assert.True(_crudService.GetAll()[0].Text == "Updated text");
            //_crudService.Remove(data.Id);
            //Assert.True(_crudService.GetAll().Count == 0);
        }

        [Fact]
        public void CrudOperationAsync()
        {
            //((IMongoDbProvider)_crudService.Provider).Client.DropDatabase("Test");
            //((IMongoDbProvider)_crudService.Provider).Client.GetDatabase("Test");
            //var data = new TestClass { Text = "test data" };
            //Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count == 0);
            //_crudService.CreateAsync(data);
            //Thread.Sleep(100);
            //Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count > 0);
            //data.Text = "Updated text";
            //_crudService.CreateOrUpdateAsync(data);
            //Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult()[0].Text == "Updated text");
            //_crudService.RemoveAsync(data.Id).GetAwaiter().GetResult();
            //Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count == 0);
        }
    }

    [Table("TestClass")]
    public class TestClass : MongoEntity
    {
        public string Text { get; set; }

        public ObjectId Id { get; set; }

        public TestClass This => this;
    }
}
