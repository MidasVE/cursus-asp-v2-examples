using Logic;
using Moq;
using NUnit.Framework;

namespace Tests {
    public class RefrigeratorTestsWithMoq {
        private Refrigerator _refrigerator;
        private Mock<IDatabase> _database;

        [SetUp]
        public void Setup () {
            _database = new Moq.Mock<IDatabase> (MockBehavior.Strict);
            _refrigerator = new Refrigerator (_database.Object);
        }

        [Test]
        public void Add_NewItemEmptyDatabase_OneIsReturned () {
            _database.Setup (x => x.AddItem ("xyz")).Returns (1);
            var id = _refrigerator.AddItem ("xyz");
            Assert.AreEqual (id, 1);
        }

        [Test]
        [Ignore ("This test is irrelevant, we don't need to test the database behaviour here")]
        public void Add_NewItem_IntIsReturned () {
            _database.Setup (x => x.AddItem ("xyz")).Returns (2);
            _refrigerator.AddItem ("dud");
            var id = _refrigerator.AddItem ("xyz");
            Assert.AreEqual (id, 2);
        }

        [Test]
        public void Get_ExistingItem_WeGetAnItemThatExists () {
            // notice that we don't need to manually add an item to the database here
            _database.Setup (x => x.GetItem (1)).Returns ("xyz");
            var item = _refrigerator.GetItem (1);
            Assert.AreEqual ("xyz", item);
        }

        [Test]
        public void Get_NonExistingItem_WeGetNull () {
            _database.Setup (x => x.GetItem (1)).Returns ((string) null);
            var item = _refrigerator.GetItem (1);
            Assert.IsNull (item);
        }
    }
}