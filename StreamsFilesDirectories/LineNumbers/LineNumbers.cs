using System.IO;
using System.Linq;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            // Read File
            string[] lines = File.ReadAllLines(inputFilePath);


            for (int i = 0; i < lines.Length; i++)
            {
                // 2. Add number of letters
                int lettersNumber = lines[i]
                    .Where(char.IsLetter)
                    .Count();

                // 3. Add number of punctuation

                int punctuationMarks = lines[i]
                        .Where(char.IsPunctuation)
                        .Count();

                // 1. Add numbers
                lines[i] = $"Line {i + 1}: {lines[i]} ({lettersNumber}) ({punctuationMarks})";
            }

            //  Write results to file
            File.WriteAllLines(outputFilePath, lines);

        }
    }
}
