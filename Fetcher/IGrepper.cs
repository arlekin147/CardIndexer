using System.Collections.Generic;

namespace CardIndexer.Fetcher {
    public interface IGrepper
    {
        IEnumerable<List<Dictionary<string, string>>> Fetch(string sheetsId, string tableName);
    }
}