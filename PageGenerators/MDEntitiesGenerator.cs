using System.Collections.Generic;
using System.IO;

namespace CardIndexer.PageGenerators
{
    class MDEntitiesGenerator : IEntitiesGenerator
    {
        public void Generate(string path, IEnumerable<List<Dictionary<string, string>>> entityGroups, IEnumerator<string> ids)
        {
            foreach (var group in entityGroups)
            {
                foreach (var entity in group)
                {
                    string id = ids.Current;
                    using (StreamWriter writter = new StreamWriter(string.Format("{0}{1}{2}.md", path, Path.DirectorySeparatorChar, id)))
                    {
                        writter.WriteLine("title: \"{0}\"", 'A');
                        writter.WriteLine("date: {0}", "");
                        writter.WriteLine("draft: {0}", "false");

                        foreach (var record in entity)
                        {
                            if (record.Key.Equals("_id"))
                            {
                                continue;
                            }

                            writter.WriteLine("{{<reg_pair key = \"{0}\" value = \"{1}\">}}", record.Key, record.Value);
                        }
                    }
                }
            }
        }
    }
}