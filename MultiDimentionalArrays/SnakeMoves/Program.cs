namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadIntArray();
            string snake = Console.ReadLine();
            string[,] matrix = new string[sizes[0], sizes[1]];

            int snakeCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0) //  current row is an even number
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
                }
                else // current row is an odd number
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }

        static int GetSnakeValue(string snake, int snakeCounter)
        {
            snakeCounter++;
            if (snakeCounter >= snake.Length)
            {
                snakeCounter = 0;
            }

            return snakeCounter;
        }

        

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
