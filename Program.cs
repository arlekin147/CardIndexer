using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CardIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var grepper = new Grepper();
            grepper.Process("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data", "Person", new List<string>{"Student Name", "Major"});
        }
    }
}