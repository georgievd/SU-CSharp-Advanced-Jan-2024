namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            // Reading data
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] newRow = ReadStringArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = newRow[col];
                }
            }

            while (true)
            {
                string[] commandTokens = ReadStringArray();

                string command = commandTokens[0];

                if (command == "END")
                {
                    break;
                }

                if (command == "swap" && commandTokens.Length == 5)
                {
                    int row1 = int.Parse(commandTokens[1]);
                    int col1 = int.Parse(commandTokens[2]);
                    int row2 = int.Parse(commandTokens[3]);
                    int col2 = int.Parse(commandTokens[4]);

                    if (IsValidSwap(matrix, row1, col1, row2, col2))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row,col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool IsValidSwap(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            return row1 >= 0 && row1 < matrix.GetLength(0)
                             && col1 >= 0 && col1 < matrix.GetLength(1)
                             && row2 >= 0 && row2 < matrix.GetLength(0)
                             && col2 >= 0 && col2 < matrix.GetLength(1);
        }

        private static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
