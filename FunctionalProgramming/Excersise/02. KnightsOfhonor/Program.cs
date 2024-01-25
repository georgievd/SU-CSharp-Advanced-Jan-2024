namespace _02._KnightsOfhonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] knightCandidates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> promoteToKnight = s => Console.WriteLine($"Sir {s}");

            Array.ForEach(knightCandidates, promoteToKnight);
        }
    }
}
