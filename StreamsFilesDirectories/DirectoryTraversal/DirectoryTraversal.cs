using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            var reportContent = TraverseDirectory(path);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        // Method to get all extensions and all files
        public static Dictionary<string, List<FileInfo>> TraverseDirectory(string inputFolderPath)
        {
            // Dictionary to store 1. file extension as key, 2. Add files to the list
            // We are using FileInfo as it includes more info - size, full name, extension
            Dictionary<string, List<FileInfo>> fileDictionary = new();

            // Read all files from the inputFolderPath
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                string extension = info.Extension;

                // Check if extension already exists 
                if (fileDictionary.ContainsKey(extension) == false)
                {
                    fileDictionary.Add(extension, new List<FileInfo>());
                }
                fileDictionary[extension].Add(info);
            }
            return fileDictionary;
        }

        public static void WriteReportToDesktop(Dictionary<string, List<FileInfo>> fileDictionary, string reportFileName)
        {
            // Create the full file path to store the report
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            // Create a SW to write data to file
            using StreamWriter writer = new StreamWriter(path);

            // 1. Order the dictionary: the number of files by type and then by name
            foreach (var item in fileDictionary
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => x.Key))
            {
                writer.WriteLine($"{item.Key}");

                foreach (var file in item.Value.OrderBy(x => x.Length))
                {
                    writer.WriteLine($"--{file.Name} - {Math.Ceiling((double)file.Length / 1024)}kb");
                }
            }
        }
    }
}
