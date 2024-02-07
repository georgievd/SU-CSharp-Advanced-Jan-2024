using System.Globalization;

namespace Generics
{
    public class Startup
    {
        static void Main()
        {
            // GenericBoxInts();
            // CallGenericSwap();
            // DoubleComparison();
            // ExerciseTuple();

            string[] nameTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beerTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] bankTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string townName = nameTokens.Length == 5 ? $"{nameTokens[3]} {nameTokens[4]}" : nameTokens[3];


            Threeuple<string, string, string> names = new($"{nameTokens[0]} {nameTokens[1]}", nameTokens[2], townName);
            Threeuple<string, int, bool> beers = new(beerTokens[0], int.Parse(beerTokens[1]),
                beerTokens[2] == "drunk");
            Threeuple<string, double, string> account = new(bankTokens[0],
                double.Parse(bankTokens[1], CultureInfo.InvariantCulture), bankTokens[2]);

            Console.WriteLine(names);
            Console.WriteLine(beers);
            Console.WriteLine(account);
        }

        private static void ExerciseTuple()
        {
            string[] nameTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beerTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] numberTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string townName;

            CustomTuple<string, string> names = new($"{nameTokens[0]} {nameTokens[1]}", nameTokens[2]);
            CustomTuple<string, int> beers = new(beerTokens[0], int.Parse(beerTokens[1]));
            CustomTuple<int, double> numbers = new(int.Parse(numberTokens[0]),
                double.Parse(numberTokens[1], CultureInfo.InvariantCulture));

            Console.WriteLine(names);
            Console.WriteLine(beers);
            Console.WriteLine(numbers);
        }

        private static void DoubleComparison()
        {
            int lines = int.Parse(Console.ReadLine());

            Box<double> myBox = new();

            for (int i = 0; i < lines; i++)
            {
                myBox.Add(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            }
            double comapreWith = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine(myBox.Count(comapreWith));
        }


        private static void CallGenericSwap()
        {
            int lines = int.Parse(Console.ReadLine());
            List<int> list = new();
            for (int i = 0; i < lines; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            GenericSwap(list, indexes[0], indexes[1]);

            foreach (var listItem in list)
            {
                Console.WriteLine($"{listItem.GetType()}: {listItem}");
            }
        }

        private static void GenericBoxInts()
        {
            int lines = int.Parse(Console.ReadLine());

            Box<int> intBox = new Box<int>();
            for (int i = 0; i < lines; i++)
            {
                intBox.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(intBox);
        }

        public static void GenericSwap<T>(List<T> items, int firstIndex, int secondIndex)
        {
            // Option 1: 
            //T temp = items[firstIndex];
            //items[firstIndex] = items[secondIndex];
            //items[secondIndex] = temp;

            // Option 2:
            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }
    }
}
