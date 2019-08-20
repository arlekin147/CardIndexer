using System.Collections.Generic;
using System.Linq;
using NLog;

namespace CardIndexer.Filter {
    public class ImportanceFilter : IFilter
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        // private readonly IList<string> _mainFields;
        // public ImportanceFilter(IList<string> mainFields)
        // {
        //     _mainFields = mainFields;
        //     _logger.Trace("Main field are {mainFields}", mainFields);
        // }
        public IEnumerable<List<Dictionary<string, string>>> Accept(IEnumerable<List<Dictionary<string, string>>> source, IList<string> mainFields)
        {
            var result = source.Select(
                group => group.Select(
                    item => item.Where(
                        field => mainFields.Any(mainField => mainField.Equals(field.Key))
                    ).ToDictionary(field => field.Key, field => field.Value)
                ).ToList()
            );
            return result;
        }
    }
}