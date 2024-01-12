using System.Globalization;

namespace MinAndMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> integerStack = new ();
            
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (input[0] == 1)
                {
                    integerStack.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    integerStack.Pop();
                }
                else if (input[0] == 3 && integerStack.Any())
                {
                    Console.WriteLine(integerStack.Max());
                }
                else if (input[0] == 4 && integerStack.Any())
                {
                    Console.WriteLine(integerStack.Min());   
                }
            }

            Console.WriteLine(string.Join(", ", integerStack));
        }
    }
}
