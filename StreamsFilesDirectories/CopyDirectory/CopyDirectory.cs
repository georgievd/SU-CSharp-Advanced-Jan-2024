﻿using System.IO;

namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            // Recreate the output path
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);
           
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(outputPath, fileName);
                File.Copy(file, destination);
            }
        }
    }
}
