using System.Collections.Generic;

namespace CardIndexer.Filter {
    public interface IFilter
    {
        IEnumerable<List<Dictionary<string, string>>> Accept(IEnumerable<List<Dictionary<string, string>>> source, IList<string> mainFields);
    }
}