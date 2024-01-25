using System.IO;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            // Create one stream to read the file
            using FileStream readStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);

            // Create second stream to write the file
            using FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);

            // Setting the buffer
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
