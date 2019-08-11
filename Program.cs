using System.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CardIndexer.Configuration;
using NLog;

namespace CardIndexer
{
    class Program
    {

        private static Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var grepper = new SheetsGrepper();
            var data = grepper.Fetch("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data");
            data = new ImportanceFilter(new List<string>{"Student Name", "Major"}).Accept(data);
            foreach (var group in data) {
                Console.WriteLine("Group begins");
                foreach (var item in group) {
                    Console.WriteLine("Item begins");
                    foreach (var field in item) {
                        Console.WriteLine(String.Format("{0}: {1}", field.Key, field.Value));
                    }
                }
            }

            IConfigurationParser parser = new TomlConfigurationParser("test.toml");
            Console.WriteLine("Source: " + parser.Source);
            foreach(var entity in parser.DataModels){
                Console.WriteLine("Model: " + entity.Key);
                foreach(var field in entity.Value){
                    Console.WriteLine("Field: " + field);
                }
            }

            Console.Read();
        }
    }
}