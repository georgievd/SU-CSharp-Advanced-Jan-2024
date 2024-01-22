namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new();

            FillWardrobe(lines, wardrobe);

            string[] searchItem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");

                    if (color.Key == searchItem[0] && item.Key == searchItem[1])
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void FillWardrobe(int lines, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] newEntry = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = newEntry[0];
                string[] newClothes  = newEntry[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                AddColorToWardrobe(wardrobe, color);
                AddClothesToColor(newClothes, wardrobe, color);
            }
        }

        private static void AddClothesToColor(string[] newClothes, Dictionary<string, Dictionary<string, int>> wardrobe, string color)
        {
            foreach (string item in newClothes)
            {
                if (wardrobe[color].ContainsKey(item) == false)
                {
                    wardrobe[color].Add(item, 1);
                }
                else
                {
                    wardrobe[color][item]++;
                }
            }
        }

        private static void AddColorToWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string color)
        {
            if (wardrobe.ContainsKey(color) == false)
            {
                wardrobe.Add(color, new Dictionary<string, int>());
            }
        }
    }
}
