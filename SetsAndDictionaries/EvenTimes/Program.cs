using System.Runtime.InteropServices;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new();

            for (int i = 0; i < lines; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers.Add(currentNumber, 1);
                }
            }

            foreach (int number in numbers.Keys)
            {
                if (numbers[number] % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }

        }
    }
}
