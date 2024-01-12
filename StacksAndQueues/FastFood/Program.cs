namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine()); // Total food for the day

            // Orders for the day
            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            if (ordersQueue.Any())
            {
                Console.WriteLine(ordersQueue.Max());
            }

            while (ordersQueue.Any())
            {
                if (foodQuantity >= ordersQueue.Peek())
                {
                    foodQuantity -= ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(' ', ordersQueue)); 
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
