using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public IEnumerable<string> GetAllItems (string startsWith) {
            // TODO 
            throw new NotImplementedException ();
        }

        public void UpdateItem (int id, string newValue) {
            // TODO
            throw new NotImplementedException ();
        }

        public void DeleteItem (int id, string newValue) {
            // TODO
            throw new NotImplementedException ();
        }
    }

}