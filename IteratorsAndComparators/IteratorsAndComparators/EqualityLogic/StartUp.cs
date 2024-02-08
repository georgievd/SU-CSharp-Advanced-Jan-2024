namespace EqualityLogic
{
    public class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);

        }
    }
}
