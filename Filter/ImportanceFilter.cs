using System.Collections.Generic;
using System.Linq;
using NLog;

namespace CardIndexer {
    class ImportanceFilter : IFilter
    {
        static Logger _logger = LogManager.GetCurrentClassLogger();
        IList<string> _mainFields;
        public ImportanceFilter(IList<string> mainFields)
        {
            _mainFields = mainFields;
            _logger.Trace("Main field are {mainFields}", mainFields);
        }
        public IEnumerable<List<Dictionary<string, string>>> Accept(IEnumerable<List<Dictionary<string, string>>> source)
        {
            var result = source.Select(
                group => group.Select(
                    item => item.Where(
                        field => _mainFields.Any(mainField => mainField.Equals(field.Key))
                    ).ToDictionary(field => field.Key, field => field.Value)
                ).ToList()
            );
            return result;
        }
    }
}