using System.Collections;
using System.Collections.Generic;

namespace CardIndexer.IDGenerators
{
    public class SimpleIdGenerator : IEnumerator<string>
    {
        private int _currentId = 0;
        public string Current => "ent" + _currentId;

        object IEnumerator.Current => throw new System.NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentId++;
            return true;
        }

        public void Reset()
        {
            _currentId = 0;
        }
    }
}