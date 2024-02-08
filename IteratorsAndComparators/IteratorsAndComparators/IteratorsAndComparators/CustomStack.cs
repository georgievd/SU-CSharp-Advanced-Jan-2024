using System.Collections;

namespace IteratorsAndComparators
{
    internal class CustomStack<T> : IEnumerable<T> 
    {
        private const int InitialCapacity = 4;
        private T[] _stack;
        public int Count { get; private set; }

        public CustomStack()
        {
            Count = 0;
            _stack = new T[InitialCapacity];
        }

        public CustomStack(int size) : this()
        {
            _stack = new T[size];
        }

        public void Push(T input)
        {
            if (Count >= _stack.Length)
            {
                Resize();
            }

            _stack[Count] = input;
            Count++;
        }

        private void Resize()
        {
            T[] temp = new T[InitialCapacity * 2];
            for (int i = 0; i < _stack.Length; i++)
            {
                temp[i] = _stack[i];
            }

            _stack = temp;
        }

        public T Peek()
        {
            return _stack[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _stack[--Count];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
