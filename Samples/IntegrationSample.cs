using System;
using CardIndexer.Configuration;
using CardIndexer.Fetcher;
using CardIndexer.Filter;

namespace CardIndexer.Samples
{
    public class IntegrationsSample : ISample
    {
        public void Run()
        {
            var grepper = new SheetsGrepper();
            var data = grepper.Fetch("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data");
            IConfigurationParser parser = new TomlConfigurationParser("test.toml");
            Console.WriteLine("Source: " + parser.Source);
            foreach (var entity in parser.DataModels)
            {
                Console.WriteLine("Model: " + entity.Key);
                foreach (var field in entity.Value)
                {
                    Console.WriteLine("Field: " + field);
                }
            }
            IFilter filter = new ImportanceFilter();
            foreach (var entity in parser.DataModels)
            {
                data = filter.Accept(data, entity.Value);
                foreach (var group in data)
                {
                    Console.WriteLine("Group begins");
                    foreach (var item in group)
                    {
                        Console.WriteLine("Item begins");
                        foreach (var field in item)
                        {
                            Console.WriteLine(String.Format("{0}: {1}", field.Key, field.Value));
                        }
                    }
                }
            }
        }
    }
}