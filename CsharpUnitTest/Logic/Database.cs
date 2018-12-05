using System.Collections.Generic;
using System.Linq;

namespace Logic {
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