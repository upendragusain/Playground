using System;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace CSharpGeneral
{
    public class UsingStreams
    {
        private const string FILE_NAME = @"csharptest.dat";


        public static void Run()
        {
            var folderPath = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.Parent.FullName;

            var filePath = Path.Combine(folderPath, FILE_NAME);

            int[] intArray = Enumerable.Range(0, 255).ToArray();
            byte[] byteArray = new byte[255];
            Buffer.BlockCopy(intArray, 0, byteArray, 0, byteArray.Length);
            WriteByteDataToFile(filePath, byteArray);

            //var data2 = new UTF8Encoding().GetBytes("Upendra Singh Gusain");
            //WriteByteDataToFile(filePath, data2);
        }

        private static void WriteByteDataToFile(string filePath, byte[] data)
        {
            using (FileStream fileStream = new FileStream(
                filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    fileStream.WriteByte(data[i]);
                }
            }
        }

        public static void MSDocsExample()
        {
            const string fileName = "Test#@@#.dat";

            // Create random data to write to the file.
            byte[] dataArray = new byte[100000];
            new Random().NextBytes(dataArray);

            using (FileStream
                fileStream = new FileStream(fileName, FileMode.Create))
            {
                // Write the data to the file, byte by byte.
                for (int i = 0; i < dataArray.Length; i++)
                {
                    fileStream.WriteByte(dataArray[i]);
                }

                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");
                        return;
                    }
                }
                Console.WriteLine("The data was written to {0} " +
                    "and verified.", fileStream.Name);
            }
        }


        public static void ReadFileIntoABuffer()
        {
            string filename = "TestFile.txt";
            char[] buffer;

            //BaseStream: returns the underlying stream!
            using (var sr = new StreamReader(filename))
            {
                buffer = new char[(int)sr.BaseStream.Length];
                //Reads a specified maximum of characters from the current stream into a buffer, 
                //beginning at the specified index.
                sr.Read(buffer, 0, (int)sr.BaseStream.Length);
            }

            WriteLine(new string(buffer));
        }
        public static void ReadFileUsingEndOfStream()
        {
            using (var fileStream = new FileStream("TestFile.txt", FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        WriteLine(line);
                    }
                }
            }
        }

        public static void WriteToFileUsingEndOfStream()
        {
            using (var fileStream = new FileStream("TestFile.txt", FileMode.Open))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    var line = "This is a newly added line from code.";
                    streamWriter.WriteLine(line);// will overwrite the content/ replacing it
                    WriteLine($"Wrote new line to file: {line}");
                }
            }
        }

        public static void ReadFileUsingEndOfStream2()
        {
            using (var streamReader = new StreamReader("TestFile.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    WriteLine(line);
                }
            }
        }

        public static void ReadAndWrite()
        {
            using (var streamReader = new StreamReader("TestFile.txt"))
            {
                using (var streamWriter = new StreamWriter("Output.txt", true))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        streamWriter.WriteLine(line.ToUpperInvariant());
                    }
                }
            }
        }
    }
}
