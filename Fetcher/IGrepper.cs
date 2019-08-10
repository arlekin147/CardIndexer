using System.Collections.Generic;

namespace CardIndexer {
    interface IGrepper
    {
        IEnumerable<List<Dictionary<string, string>>> Fetch(string sheetsId, string tableName);
    }
}