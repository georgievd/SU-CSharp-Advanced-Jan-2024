using System.Collections;

namespace IteratorsAndComparators
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> _list;

        public Lake(List<int> list)
        {
            _list = list;
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return _list[i];
                }
            }

            for (int i = _list.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return _list[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
