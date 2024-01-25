namespace _05._Agefilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int lines = int.Parse(Console.ReadLine());

            Person[] people = new Person[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }


            var temp = people.Select(p => p.Name).ToArray();

            // Read filer data
            string filter = Console.ReadLine(); // store the filter - older/younger
            int filterAge = int.Parse(Console.ReadLine()); // Age
            string format = Console.ReadLine(); // Format of the output

            // Create references to methods
            Func<Person, bool> predicate = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = GetFormatter(format);

            PrintPeople(people, predicate, formatter);

            static void PrintPeople(Person[] people, Func<Person, bool> predicate, Func<Person, string> formatter)
            {
                foreach (Person person in people)
                {
                    if (predicate(person))
                    {
                        Console.WriteLine(formatter(person));
                    }
                }
            }

            static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
            {
                if (filter == "younger")
                {
                    return p => p.Age < filterAge; // Predicate to return true if person is younger
                }
                else if (filter == "older")
                {
                    return p => p.Age >= filterAge;
                }
                return null;
            }

            static Func<Person, string> GetFormatter(string format)
            {
                if (format == "name")
                {
                    return p => $"{p.Name}";
                }
                else if (format == "age")
                {
                    return p => $"{p.Age}";
                }
                else if (format == "name age")
                {
                    return p => $"{p.Name} - {p.Age}";
                }

                return null;
            }
        }
    }

    // Declare our own type
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
