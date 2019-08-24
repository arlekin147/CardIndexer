using System;
using System.Collections.Generic;
using System.IO;
using CardIndexer.Configuration;

namespace CardIndexer.PageGenerators
{
    public class MDIndexGenerator : IIndexGenerator
    {
        public void Generate(
            List<Dictionary<string, string>> intities,
            IEnumerator<string> listOfID,
            string destinationPath)
        {
            System.Console.WriteLine("aga");
            using (var stream = new StreamWriter(File.Create(destinationPath + @"\_index.md")))
            {
                stream.WriteLine("---");
                stream.WriteLine("title: \"Ipsum\"");
                stream.WriteLine("date: " + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK"));
                stream.WriteLine("draft: false");
                stream.WriteLine("---");
                foreach (var entity in intities)
                {
                    if(!listOfID.MoveNext()) throw new InvalidNumeratorException();
                    var mainFields = "";
                    foreach(var field in entity)
                    {
                        mainFields += field.Value + " ";
                    }
                    stream.WriteLine("{{" + $"<reg_link link = \"{listOfID.Current}\" name = \"{mainFields}\">" + "}}");
                }
            }
        }
    }
}
