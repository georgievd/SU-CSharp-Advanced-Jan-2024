using System.Text;

namespace ImplementingStacksAndQueues
{
    public class CustomList
    {
        #region FieldsAndProperties
        private const int InitialArraySize = 2;
        private int[] items;

        // Stores the number of elements currently in the list
        public int Count { get; private set; } = 0;

        /// <summary>
        /// This is an indexer. This allows us to get an element from the list by its index
        /// Example: list[1]
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        #endregion

        public CustomList()
        {
            items = new int[InitialArraySize]; //Avoid 'Magic Numbers'
        }

        /// <summary>
        /// This is a method to add an element to the list
        /// </summary>
        /// <param name="element"></param>
        public void Add(int element)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }
            items[Count] = element;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentNullException();
            }
            int result = items[index];
            ShiftLeft(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                ShrinkCapacity();
            }

            return result;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        // TODO: Implement
        public void Swap(int firstIndex, int secondIndex)
        {
            if (IsIndexValid(firstIndex, secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                sb.Append($"{items[i]} ");
            }
            return sb.ToString().TrimEnd();
        }

        private bool IsIndexValid(int firstIndex, int secondIndex)
        {
            return firstIndex < 0
                   || secondIndex < 0
                   || firstIndex >= Count
                   || secondIndex >= Count;
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

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void ShrinkCapacity()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
    }
}
