namespace StacksAndQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine()
            //    .Split(' ');
            //int n = int.Parse(input[0]);
            //int s = int.Parse(input[1]);
            //int x = int.Parse(input[2]);

            // Read the first line from console
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            // Read 2nd line from console
            string[] secondLine = Console.ReadLine().Split(' ');

            Stack<int> integerStack = new();

            // Parse and add int elements to stack
            foreach (var s in secondLine)
            {
                int temp = int.Parse(s);
                integerStack.Push(temp);
            }

            
            // Remove s elements from stack
            for (int i = 0; i < input[1]; i++)
            {
                integerStack.Pop();
            }


            if (integerStack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if (integerStack.Any())
            {
                Console.WriteLine(integerStack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
