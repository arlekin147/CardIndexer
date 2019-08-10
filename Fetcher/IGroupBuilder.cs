using System.Collections.Generic;

namespace CardIndexer {
    interface IGroupBuilder {
        void startNewGroup(int groupId);
        void finalizeGroup();
        List<Dictionary<string, string>> toGroupList();
        void addProperty(string key, string value);
    };
}