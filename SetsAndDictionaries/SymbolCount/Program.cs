namespace SymbolCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> charCounter = new();

            foreach (char c in input)
            {
                if (charCounter.ContainsKey(c))
                {
                    charCounter[c]++;
                }
                else
                {
                    charCounter.Add(c, 1);
                }
            }

            foreach (char c in charCounter.Keys)
            {
                Console.WriteLine($"{c}: {charCounter[c]} time/s");
            }
        }
    }
}
