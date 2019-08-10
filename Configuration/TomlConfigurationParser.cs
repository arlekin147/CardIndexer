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
            try
            {
                Source = toml["Source"]["googleSheetSource"];
            }
            catch (KeyNotFoundException e)
            {
                throw new SourceNotFoundException("Configuration file must" +
                    "contains Source string", e);
            }
            foreach (var entity in toml)
            {
                switch (entity.Key)
                {
                    case "DataModel":
                        {
                            try
                            {
                                DataModels.Add(
                                    entity.Value["name"],
                                    new List<string>(entity.Value["mainFields"].ToArrayOf<string>()));
                            }
                            catch (FormatException e)
                            {
                                throw new FormatException("Wrong format in description of model"
                                 + entity.Key, e);
                            }
                            break;
                        }
                }
            }
        }

        public string Source { get; private set; }
        public Dictionary<string, List<string>> DataModels { get; private set; }
    }
}