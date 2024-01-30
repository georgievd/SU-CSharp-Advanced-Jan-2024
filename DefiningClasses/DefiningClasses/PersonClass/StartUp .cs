using PersonClass;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            // Excersise1();
            // Excersise2();
            // Excersise3();
            // Excersise4();

            string[] dates = new string[2];
            for (int i = 0; i < 2; i++)
            {
                dates[i] = Console.ReadLine();
            }

            DateModifier dateModifier = new DateModifier(dates[0], dates[1]);
            Console.WriteLine(dateModifier.CalculateDifferenceInDays());

        }

        private static void Excersise4()
        {
            List<Person> people = new List<Person>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(input[0], int.Parse(input[1])));
            }

            var result = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name);

            foreach (Person person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        private static void Excersise3()
        {
            int lines = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        private static void Excersise2()
        {
            var person1 = new Person();
            var person2 = new Person(15);
            var person3 = new Person("Pesho", 32);

            Console.WriteLine($"{person1.Name} {person1.Age}");
            Console.WriteLine($"{person2.Name} {person2.Age}");
            Console.WriteLine($"{person3.Name} {person3.Age}");
        }

        private static void Excersise1()
        {
            Person Peter = new Person
            {
                Name = "Peter",
                Age = 20
            };

            Person George = new("George", 18);
            var Jose = new Person("Jose", 43);
        }
    }
}
