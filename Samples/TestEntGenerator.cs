using CardIndexer.Fetcher;
using CardIndexer.PageGenerators;
using System.Collections.Generic;
using System.Linq;


namespace CardIndexer.Samples {
    class TestEntGenerator : ISample
    {
        public void Run()
        {
            var grepper = new SheetsGrepper();
            var data = grepper.Fetch("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data");

            new MDEntitiesGenerator().Generate("content", data, Enumerable.Range(0, 100).Select(x => x.ToString()).GetEnumerator());

            // foreach (var kek in Enumerable.Range(0, 100).Select(x => x.ToString())) {
            //     System.Console.WriteLine(kek);
            // }
        }
    }
}