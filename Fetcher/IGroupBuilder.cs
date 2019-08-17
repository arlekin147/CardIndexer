using System.Collections.Generic;

namespace CardIndexer.Fetcher {
    public interface IGroupBuilder {
        void StartNewGroup(int groupId);
        void FinalizeGroup();
        List<Dictionary<string, string>> ToGroupList();
        void AddProperty(string key, string value);
    };
}