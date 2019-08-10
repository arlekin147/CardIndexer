using System.Collections.Generic;

namespace CardIndexer {
    class KeyValueBuilder : IGroupBuilder {

        List<Dictionary<string, string>> groups;
        Dictionary<string, string> currentGroup;
        public KeyValueBuilder() {
            groups = new List<Dictionary<string, string>>{};
        }
        public void startNewGroup(int groupId) {
            if (currentGroup != null) {
                finalizeGroup();
            }
            currentGroup = new Dictionary<string, string>{["_id"] = groupId.ToString()};
        }

        public void finalizeGroup() {
            if (currentGroup == null) {
                throw new System.InvalidOperationException();
            }
            groups.Add(currentGroup);
            currentGroup = null;
        }

        public void addProperty(string key, string value) {
            if (currentGroup == null) {
                throw new System.InvalidOperationException();
            }
            currentGroup.Add(key, value);
        }

        public List<Dictionary<string, string>> toGroupList() {
            if (currentGroup != null) {
                finalizeGroup();
            }
            return groups;
        }
    }
}