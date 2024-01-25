namespace _07._PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> predicate = (s, i) => s.Length <= i;

            var result = names.Where(name => predicate(name, length));

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
