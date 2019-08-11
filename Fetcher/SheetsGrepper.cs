using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System;

namespace CardIndexer {
    class SheetsGrepper : IGrepper {
        static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        static string[] _scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string _applicationName = "CardIndexer";

        UserCredential _credential;
        SheetsService _service;

        public SheetsGrepper() {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                _credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                _logger.Trace("Credential file saved to: {0}", credPath);
            }

            _service =  new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = _applicationName,
            });

            _logger.Trace("Service established");
        }
        public IEnumerable<List<Dictionary<string, string>>> Fetch(string sheetsId, string tableName)
        {
            // TODO to extend maximum row further Z
            var propertyValues = _service.Spreadsheets.Values.Get(sheetsId, String.Format("{0}!A{1}:Z{2}", tableName, 1, 1)).Execute().Values;
            if (propertyValues == null || propertyValues.Count == 0) {
                _logger.Warn("Property row not found. No data will be acquired");
                yield break;
            }
            _logger.Trace("Property row found and non-empty");

            var propertyRow = propertyValues[0];
            int propertiesCount = propertyRow.Count;
            
            for (int group = 0; ; group++) {
                const int groupSize = 10;
                // TODO to extend maximum row further Z
                SpreadsheetsResource.ValuesResource.GetRequest request = _service.Spreadsheets.Values.Get(sheetsId, String.Format("{0}!A{1}:Z{2}", tableName,
                                                                                                        group * groupSize + 2, (group + 1) * groupSize + 1));
                var response = request.Execute();
                if (response.Values == null || response.Values.Count == 0) {
                    _logger.Trace("End of rows");
                    break;
                }
                _logger.Trace("New response in processing");

                IGroupBuilder builder = new KeyValueBuilder();
                for (int rowId = 0; rowId < response.Values.Count; rowId++)
                {
                    var recordId = (group * groupSize + 2) + rowId;
                    builder.StartNewGroup(recordId);
                    var row = response.Values[rowId];
                    for (int i = 0; i < propertiesCount; i++)
                    {
                        var currentKey = propertyRow[i].ToString();
                        string value;
                        if (i >= row.Count)
                        {
                            value = "";
                        }
                        else
                        {
                            value = row[i].ToString();
                        }
                        
                        if (value.Equals(""))
                        {
                            _logger.Warn("{0};{1} indexed cell is empty which is unexpected", recordId, i);
                        }
                        
                        builder.AddProperty(currentKey, value);
                        _logger.Trace("Parametes added to {0};{1} as {2}: {3}", recordId, i, currentKey, value);
                    }
                    builder.FinalizeGroup();
                }
                _logger.Trace("End of processing a response");
                yield return builder.ToGroupList();
            }
            yield break;
        }
    }
}