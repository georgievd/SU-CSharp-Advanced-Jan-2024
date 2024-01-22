using System.Runtime.CompilerServices;

namespace SetsAndDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUserNames = new();

            for (int i = 0; i < lines; i++)
            {
                string username = Console.ReadLine();
                uniqueUserNames.Add(username);
            }

            foreach (string userName in uniqueUserNames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
