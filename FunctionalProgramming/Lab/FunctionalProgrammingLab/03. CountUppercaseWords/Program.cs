namespace _03._CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Initialize predicate and assign anon. function - lambda
            Predicate<string> checker = word => char.IsUpper(word[0]);

            // Filter using the predicate
            words = words.Where(w => checker(w)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));

        }
    }
}
