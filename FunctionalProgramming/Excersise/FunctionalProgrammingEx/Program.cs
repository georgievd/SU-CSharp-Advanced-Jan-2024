namespace FunctionalProgrammingEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> print = s => Console.WriteLine(s);
           
          //  Action<string> print2 = Print;

            Array.ForEach(input, print);
        }

        //static void Print(string s)
        //{
        //    Console.WriteLine(s);
        //}
    }
}
