using System.Collections.Generic;

namespace CardIndexer.Configuration
{
    public interface IConfigurationParser
    {
        string Source { get; }
        Dictionary<string, List<string>> DataModels { get; }

    }
}