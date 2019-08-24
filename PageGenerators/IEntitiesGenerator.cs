using System.Collections.Generic;

namespace CardIndexer.PageGenerators
{
    public interface IEntitiesGenerator
    {
        void Generate(string path, IEnumerable<List<Dictionary<string, string>>> entityGroups, IEnumerator<string> ids);
    }
}