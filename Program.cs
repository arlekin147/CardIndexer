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
using CardIndexer.Samples;
using CardIndexer.PageGenerators;

namespace CardIndexer
{
    class Program
    {

        private static Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            new IntegrationsSample().Run();
            new IndexGeneratorSample().Run();
            Console.Read();
        }
    }
}