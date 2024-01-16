namespace MultiDimentionalArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int sumDiagonalOne = 0;
            int sumDiagonalTwo = 0;

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] newRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = newRow[col];

                    if (row == col)
                    {
                        sumDiagonalOne += matrix[row, col];
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                sumDiagonalTwo += matrix[row, size - 1 - row];
            }
            Console.WriteLine(Math.Abs(sumDiagonalOne - sumDiagonalTwo));

        }
    }
}
