namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> integerQueue = new Queue<int>(secondLine);

            for (int i = 0; i < firstLine[1]; i++)
            {
                integerQueue.Dequeue();
            }

            if (!integerQueue.Any())
            {
                Console.WriteLine(0);
            }
            else if (integerQueue.Contains(firstLine[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(integerQueue.Min());
            }

        }
    }
}
