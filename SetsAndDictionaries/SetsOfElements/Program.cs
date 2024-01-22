namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lines = Console.ReadLine()
                .Split(' ',  StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lines[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < lines[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            // Option 1: IntersectWith - from HashSet<T>
            firstSet.IntersectWith(secondSet);

            //Option 2: New set - LINQ method
           // var newSet = firstSet.Intersect(secondSet);

            foreach (int i in firstSet)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
