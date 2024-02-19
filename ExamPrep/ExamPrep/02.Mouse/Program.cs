namespace _02.Mouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] cupboard = new char[dimensions[0], dimensions[1]];
            int totalPiecesOfCheese = 0;
            int mouseCol = -1;
            int mouseRow = -1;

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                string newRow = Console.ReadLine();
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    cupboard[i, j] = newRow[j];
                    if (newRow[j] == 'M')
                    {
                        mouseCol = j;
                        mouseRow = i;
                        cupboard[mouseRow, mouseCol] = '*';
                    }
                    if (newRow[j] == 'C')
                    {
                        totalPiecesOfCheese++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                // Check if mouse goes outside the cupboard
                // We do this check, because this action leads to end-game
                if (CheckIfMouseStepedOutside(command, mouseCol, cupboard, mouseRow)) break;

                switch (command)
                {
                    // Mouse tries to go through a wall, ignore command
                    case "left" when cupboard[mouseRow, mouseCol - 1] == '@':
                    case "right" when cupboard[mouseRow, mouseCol + 1] == '@':
                    case "up" when cupboard[mouseRow - 1, mouseCol] == '@':
                    case "down" when cupboard[mouseRow + 1, mouseCol] == '@':
                        continue;
                    // Otherwise, move mouse
                    case "left":
                        mouseCol--; break;
                    case "right":
                        mouseCol++; break;
                    case "up":
                        mouseRow--; break;
                    case "down":
                        mouseRow++; break;
                }

                // Check if mouse got to a cell with cheese on it
                if (cupboard[mouseRow, mouseCol] == 'C')
                {
                    totalPiecesOfCheese--; // mouse eats the cheese
                    cupboard[mouseRow, mouseCol] = '*'; // mark the cell as empty
                    if (totalPiecesOfCheese == 0)
                    {
                        cupboard[mouseRow, mouseCol] = 'M'; // Last known mouse pos.
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                    continue;
                }

                if (cupboard[mouseRow, mouseCol] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
            }

            if (command == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }
            cupboard[mouseRow, mouseCol] = 'M';

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    Console.Write(cupboard[i, j]);
                }

                Console.WriteLine();
            }

        }

        private static bool CheckIfMouseStepedOutside(string? command, int mouseCol, char[,] cupboard, int mouseRow)
        {
            if (command == "left" && mouseCol == 0 ||
                command == "right" && mouseCol == cupboard.GetLength(1) - 1 ||
                command == "up" && mouseRow == 0 ||
                command == "down" && mouseRow == cupboard.GetLength(0) - 1)
            {
                Console.WriteLine("No more cheese for tonight!");
                return true;
            }

            return false;
        }
    }
}
