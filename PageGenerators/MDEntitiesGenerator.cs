using System.Collections.Generic;
using System.IO;
using System;
using NLog;

namespace CardIndexer.PageGenerators
{
    class MDEntitiesGenerator : IEntitiesGenerator
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public void Generate(string path, IEnumerable<List<Dictionary<string, string>>> entityGroups, IEnumerator<string> ids)
        {
            var datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
            foreach (var group in entityGroups)
            {
                foreach (var entity in group)
                {
                    if (!ids.MoveNext())
                    {
                        _logger.Error("ID generator is over unexpectedly");
                        // Replace with a custom exception
                        throw new Exception("ID generator is over unexpectedly");
                    }

                    string id = ids.Current;
                    _logger.Trace("Generating {0}", id);
                    try
                    {
                        using (StreamWriter writter = new StreamWriter(string.Format("{0}{1}{2}.md", path, Path.DirectorySeparatorChar, id)))
                        {
                            writter.WriteLine("---");
                            writter.WriteLine("title: \"{0}\"", id);
                            writter.WriteLine("date: {0}", datetime);
                            writter.WriteLine("draft: {0}", "false");
                            writter.WriteLine("---");

                            foreach (var record in entity)
                            {
                                if (record.Key.Equals("_id"))
                                {
                                    continue;
                                }

                                writter.WriteLine("{{{{<reg_pair key = \"{0}\" value = \"{1}\">}}}}", record.Key, record.Value);
                            }
                        }
                    }
                    catch (DirectoryNotFoundException e) {
                        _logger.Error(e, "No output directory");
                    }
                }
            }
        }
    }
}