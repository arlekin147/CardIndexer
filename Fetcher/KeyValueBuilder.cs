using System.Collections.Generic;

namespace CardIndexer {
    class KeyValueBuilder : IGroupBuilder {

        List<Dictionary<string, string>> _groups;
        Dictionary<string, string> _currentGroup;
        public KeyValueBuilder() {
            _groups = new List<Dictionary<string, string>>{};
        }
        public void StartNewGroup(int groupId) {
            if (_currentGroup != null) {
                FinalizeGroup();
            }
            _currentGroup = new Dictionary<string, string>{["_id"] = groupId.ToString()};
        }

        public void FinalizeGroup() {
            if (_currentGroup == null) {
                throw new System.InvalidOperationException();
            }
            _groups.Add(_currentGroup);
            _currentGroup = null;
        }

        public void AddProperty(string key, string value) {
            if (_currentGroup == null) {
                throw new System.InvalidOperationException();
            }
            _currentGroup.Add(key, value);
        }

        public List<Dictionary<string, string>> ToGroupList() {
            if (_currentGroup != null) {
                FinalizeGroup();
            }
            return _groups;
        }
    }
}