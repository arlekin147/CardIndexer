using System.Collections.Generic;

namespace CardIndexer.PageGenerators
{
    public interface IIndexGenerator
    {
        void Generate(
            List<Dictionary<string, string>> data,
            IEnumerator<string> listOfID,
            string destinationPath);
    }
}