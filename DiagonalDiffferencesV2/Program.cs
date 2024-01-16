namespace DiagonalDiffferencesV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int sumDiagonalOne = 0;
            int sumDiagonalTwo = 0;

            for (int i = 0; i < size; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                sumDiagonalOne += row[i];
                sumDiagonalTwo += row[size - 1 - i];
            }

            Console.WriteLine(Math.Abs(sumDiagonalOne - sumDiagonalTwo));
        }
    }
}
