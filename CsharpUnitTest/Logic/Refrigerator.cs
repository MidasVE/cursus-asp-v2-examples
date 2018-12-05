using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Logic {
    public class Refrigerator {
        private IDatabase _database;

        public Refrigerator (IDatabase database) {
            _database = database;
        }

        public int AddItem (string item) {
            // add more logic here
            return _database.AddItem (item);
        }

        public string GetItem (int id) {
            // add more logic here
            return _database.GetItem (id);
        }
    }

    public interface IDatabase {
        int AddItem (string input);
        string GetItem (int id);
    }

    public class Database : IDatabase {
        private Dictionary<int, string> _items;

        public Database () {
            _items = new Dictionary<int, string> ();
        }

        public int AddItem (string input) {
            var newId = _items.Any () ? _items.Keys.Max () + 1 : 1;
            _items.Add (newId, input);
            return newId;
        }

        public string GetItem (int id) {
            _items.TryGetValue (id, out var item);
            return item;
        }
    }

}