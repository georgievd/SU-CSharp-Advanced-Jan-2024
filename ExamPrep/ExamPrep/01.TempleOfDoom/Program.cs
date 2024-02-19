namespace _01.TempleOfDoom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read input
            int[] toolsArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Create Queue - FIFO
            Queue<int> tools = new Queue<int>(toolsArray);

            int[] substanceArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Create Stack - LIFO
            Stack<int> substances = new Stack<int>(substanceArray);

            List<int> challenges = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            while (true)
            {
                int result = tools.Peek() * substances.Peek();
                if (challenges.Contains(result))
                {
                    challenges.Remove(result);
                    tools.Dequeue();
                    substances.Pop();

                    if (challenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        break;
                    }
                }
                else
                {
                    // No challenge is resolved
                    tools.Enqueue(tools.Dequeue() + 1);
                    substances.Push(substances.Pop() - 1);
                    // Substance flask empty, remove it
                    if (substances.Peek() == 0)
                    {
                        substances.Pop();
                    }

                    if (substances.Count != 0 && tools.Count != 0) continue;
                    if (challenges.Count <= 0) continue;
                    // Harry has more challenges to solve, but no tools or substances
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
            }

            if (tools.Any()) Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            if (substances.Any()) Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            if (challenges.Any()) Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");

        }
    }
}
