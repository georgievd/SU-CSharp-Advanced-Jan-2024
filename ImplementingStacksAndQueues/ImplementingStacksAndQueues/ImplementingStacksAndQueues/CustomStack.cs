namespace ImplementingStacksAndQueues
{
    public class CustomStack
    {
        private int[] items;
        private const int InitialCapacity = 4;
        public int Count { get; private set; }

        public CustomStack()
        {
            items = new int[InitialCapacity];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        public void Push(int element)
        {
            if (Count == items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = element;
            Count++;
        }

        public int Pop()
        {
            CheckIfCountIsZero();

            int result = items[Count - 1];
            Count--;
            return result;
        }
        public int Peek()
        {
            CheckIfCountIsZero();

            return items[Count - 1];
        }

        private void CheckIfCountIsZero()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void IncreaseCapacity()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        


    }
}
