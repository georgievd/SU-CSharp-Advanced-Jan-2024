namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                jaggedArray[row] = ReadIntArray();
            }

            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] *= 2;
                    }
                    for (int i = 0; i < jaggedArray[row + 1].Length; i++)
                    {
                        jaggedArray[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] /= 2;
                    }
                    for (int i = 0; i < jaggedArray[row + 1].Length; i++)
                    {
                        jaggedArray[row + 1][i] /= 2;
                    }
                }
            }

            string[] tokens = ReadStringArray();

            while (tokens[0].ToLower() != "end")
            {
                if (tokens[0].ToLower() == "add")
                {
                    if (ValidateIndexes(jaggedArray, tokens))
                    {
                        jaggedArray[int.Parse(tokens[1])][int.Parse(tokens[2])] += int.Parse(tokens[3]);
                    }
                }
                if (tokens[0].ToLower() == "subtract")
                {
                    if (ValidateIndexes(jaggedArray, tokens))
                    {
                        jaggedArray[int.Parse(tokens[1])][int.Parse(tokens[2])] -= int.Parse(tokens[3]);
                    }
                }
                tokens = ReadStringArray();
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }

            static bool ValidateIndexes(int[][] matrix, string[] tokens)
            {
                return int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < matrix.GetLength(0) &&
                       int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < matrix[int.Parse(tokens[1])].Length;
            }

            static string[] ReadStringArray()
            {
                return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            static int[] ReadIntArray()
            {
                return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();
            }

        }
    }
}
