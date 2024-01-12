namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> delivery  = new Stack<int>(
                Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            int rackCapcity = int.Parse(Console.ReadLine());

            int racksUsed = 1;
            int currentRackCapacity = rackCapcity;

            while (delivery.Any())
            {
                if (delivery.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= delivery.Pop();
                }
                else
                {
                    racksUsed++;
                    currentRackCapacity = rackCapcity;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
