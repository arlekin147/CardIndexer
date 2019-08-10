﻿using Google.Apis.Auth.OAuth2;
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
            var data = grepper.Process("1wG0fe0cv157kIsbGqapP_2n8hzQRET0VspU0t6KyNuU", "Class Data", "Person");
            foreach (var group in data) {
                Console.WriteLine("Group begins");
                foreach (var item in group) {
                    Console.WriteLine("Item begins");
                    foreach (var field in item) {
                        Console.WriteLine(String.Format("{0}: {1}", field.Key, field.Value));
                    }
                }
            }
        }
    }
}