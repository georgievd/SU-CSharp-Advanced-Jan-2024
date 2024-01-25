namespace _05._AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> function = x => x;
            Action<int[]> print = numbers => Console.WriteLine(string.Join(' ', numbers));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    function = x => x + 1;
                }
                else if (command == "multiply")
                {
                    function = x => x * 2;
                }
                else if (command == "subtract")
                {
                    function = x => x - 1;
                }
                else if (command == "print")
                {
                    print(numbers);
                    continue;
                }

                numbers = numbers.Select(x => function(x)).ToArray();
            }

        }
    }
}
