using System.Threading;
using MongoDB.Bson;
using Server.Db.Providers;
using Xunit;

namespace Server.Db.Test
{
    public class CrudTests
    {
        private readonly ICrud<TestClass> _crudService;

        public CrudTests()
        {
            _crudService = new CrudDb<TestClass, IMongoDbProvider>(EDataBase.MogoDataBase, "mongodb://localhost/");
        }

        [Fact]
        public void CrudOperation()
        {
            ((IMongoDbProvider)_crudService.Provider).Client.DropDatabase("Test");
            ((IMongoDbProvider)_crudService.Provider).Client.GetDatabase("Test");
            var data = new TestClass { Text = "test data" };
            Assert.True(_crudService.GetAll().Count == 0);
            _crudService.Create(data);
            Assert.True(_crudService.GetAll().Count > 0);
            data.Text = "Updated text";
            _crudService.CreateOrUpdate(data);
            Assert.True(_crudService.GetAll()[0].Text == "Updated text");
            _crudService.Remove(data);
            Assert.True(_crudService.GetAll().Count == 0);
        }

        [Fact]
        public void CrudOperationAsync()
        {
            ((IMongoDbProvider)_crudService.Provider).Client.DropDatabase("Test");
            ((IMongoDbProvider)_crudService.Provider).Client.GetDatabase("Test");
            var data = new TestClass { Text = "test data" };
            Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count == 0);
            _crudService.CreateAsync(data);
            Thread.Sleep(100);
            Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count > 0);
            data.Text = "Updated text";
            _crudService.CreateOrUpdateAsync(data);
            Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult()[0].Text == "Updated text");
            _crudService.RemoveAsync(data).GetAwaiter().GetResult();
            Assert.True(_crudService.GetAllAsync().GetAwaiter().GetResult().Count == 0);
        }
    }

    [TableAttribute("TestClass")]
    [DatabaseNameAttribute("Test")]
    public class TestClass : IMongoDataModel<TestClass>
    {
        public string Text { get; set; }

        public ObjectId Id { get; set; }

        public TestClass This => this;
    }
}
