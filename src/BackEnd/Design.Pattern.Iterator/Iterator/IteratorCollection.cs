using System.Collections;
using Design.Pattern.Iterator.Aggregate;
using Design.Pattern.Iterator.Interfaces;

namespace Design.Pattern.Iterator.Iterator
{
    public class IteratorCollection : IIterator
    {
        private AggregateCollection _aggregate;
        private int _current = 0;

        public IteratorCollection(AggregateCollection aggregate)
        {
            _aggregate = aggregate;
        }

        public object First()
        {
            return _aggregate[0];
        }

        public object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count() - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public object Current()
        {
            return _aggregate[_current];
        }

        public int GetIndex()
        {
            return _current;
        }
    }
}
