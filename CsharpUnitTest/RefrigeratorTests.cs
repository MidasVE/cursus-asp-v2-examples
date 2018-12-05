using Logic;
using NUnit.Framework;

namespace Tests {
    public class RefrigeratorTests {
        private Refrigerator _refrigerator;
        private Database _database;

        [SetUp]
        public void Setup () {
            _database = new Database ();
            _refrigerator = new Refrigerator (_database);
        }

        [Test]
        public void Add_NewItemEmptyDatabase_OneIsReturned () {
            var id = _refrigerator.AddItem ("xyz");
            Assert.AreEqual (id, 1);
        }

        [Test]
        public void Add_NewItem_IntIsReturned () {
            _refrigerator.AddItem ("dud");
            var id = _refrigerator.AddItem ("xyz");
            Assert.AreEqual (id, 2);
        }

        [Test]
        public void Get_ExistingItem_WeGetAnItemThatExists () {
            var id = _refrigerator.AddItem ("xyz");
            var item = _refrigerator.GetItem (id);
            Assert.AreEqual ("xyz", item);
        }

        [Test]
        public void Get_NonExistingItem_WeGetNull () {
            var item = _refrigerator.GetItem (1);
            Assert.IsNull (item);
        }
    }
}