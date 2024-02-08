using System.Diagnostics;

namespace IteratorsAndComparators
{
    public class StarUp
    {
        static void Main()
        {
            //ListyIteratorSetup();
            //ForeachTheStack();
            //Lake();

            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProperties = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new()
                {
                    Name = personProperties[0],
                    Age = int.Parse(personProperties[1]),
                    Town = personProperties[2]
                };

                people.Add(person);
            }

            int referenceIndex = int.Parse(Console.ReadLine()) - 1;
            Person referencePerson = people[referenceIndex];

            int equalCount = 0;
            int differentCount = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(referencePerson) == 0)
                {
                    equalCount++;
                }
                else
                {
                    differentCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {differentCount} {people.Count}");
            }
        }

        private static void Lake()
        {
            List<int> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(list);

            string result = string.Join(", ", lake);
            Console.WriteLine(result);
        }

        private static void ForeachTheStack()
        {
            CustomStack<string> stack = new CustomStack<string>();
            string input;
            string[] delims = { ", ", " " };

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Push")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        stack.Push(command[i]);
                    }
                }
                else if (command[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static void ListyIteratorSetup()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> listy = new ListyIterator<string>(input.Skip(1).ToList());

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Print":
                        try
                        {
                            listy.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine("Invalid Operation!");
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "PrintAll":
                        foreach (var element in listy)
                        {
                            Console.Write($"{element} ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
