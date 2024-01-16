namespace SquaresInMatrixMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int squaresFound = 0;
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] newRow = ReadArrayFronConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = newRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (dimensions[0] > 1 && row <= matrix.GetLength(0) - 2 && col <= matrix.GetLength(1) - 2)
                    {
                        if (matrix[row, col] == matrix[row, col + 1]
                            && matrix[row, col] == matrix[row + 1, col]
                            && matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            squaresFound++;
                        }
                    }
                }
            }

            Console.WriteLine(squaresFound);
            string[] ReadArrayFronConsole()
            {
                return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

