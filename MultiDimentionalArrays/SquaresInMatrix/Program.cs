namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int squaresFound = 0;

            string[] previousRow = null;

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (row > 0)
                {
                    for (int col = 0; col < cols - 1; col++)
                    {
                        if (currentRow[col] == previousRow[col]
                            && previousRow[col + 1] == currentRow[col]
                            && currentRow[col + 1] == previousRow[col])
                        {
                            squaresFound++;
                        }
                    }
                }
                previousRow = currentRow;
            }

            Console.WriteLine(squaresFound);
        }
    }
}
