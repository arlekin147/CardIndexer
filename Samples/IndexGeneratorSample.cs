using System;
using CardIndexer.Configuration;
using CardIndexer.Fetcher;
using CardIndexer.Filter;
using CardIndexer.IDGenerators;
using CardIndexer.PageGenerators;

namespace CardIndexer.Samples
{
    public class IndexGeneratorSample : ISample
    {
        public void Run()
        {
            var grepper = new SheetsGrepper();
            var data = grepper.Fetch("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data");
            
            IConfigurationParser parser = new TomlConfigurationParser("test.toml");
            IFilter filter = new ImportanceFilter();
            foreach (var entity in parser.DataModels)
            {
                data = filter.Accept(data, entity.Value);
                foreach (var group in data)
                {
                    new MDIndexGenerator().Generate(
                            group,
                            new SimpleIdGenerator(),
                            @"C:\Users\14714\TestFolder"
                        );
                }
            }
        }
    }
}