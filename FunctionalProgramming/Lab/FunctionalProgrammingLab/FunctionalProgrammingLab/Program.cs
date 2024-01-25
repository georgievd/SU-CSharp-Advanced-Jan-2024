namespace FunctionalProgrammingLab
{
    internal class Program
    {
        static int someRandomVariable = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Pure function - deterministic
        static int Square(int x)
        {
            return x * x;
        }

        // Pure function
        static int Add_NotPure(int x)
        {
            if (someRandomVariable > 6)
            {
                someRandomVariable++;
                return x * x;
            }
            return x / someRandomVariable;
        }
    }
}
