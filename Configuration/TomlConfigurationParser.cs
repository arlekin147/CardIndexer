using System.Collections.Generic;
using System;
using System.IO;
using Carbon.Toml;

namespace CardIndexer.Configuration
{
    public class TomlConfigurationParser : IConfigurationParser
    {
        public TomlConfigurationParser(string filename)
        {
            DataModels = new Dictionary<string, List<string>>();
            var toml = Toml.Parse(new FileInfo(filename));
            Source = toml["Source"]["googleSheetSource"];
            foreach (var entity in toml)
            {
                switch (entity.Key)
                {
                    case "DataModel":
                        {
                            DataModels.Add(
                                entity.Value["name"],
                                new List<string>(entity.Value["mainFields"].ToArrayOf<string>()));
                            break;
                        }
                }
            }
        }

        public string Source { get; private set; }
        public Dictionary<string, List<string>> DataModels { get; private set; }
    }
}