using System.Collections.Generic;

namespace CardIndexer {
    interface IFilter
    {
        IEnumerable<List<Dictionary<string, string>>> Accept(IEnumerable<List<Dictionary<string, string>>> source);
    }
}