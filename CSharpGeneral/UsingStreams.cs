using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using static System.Console;

namespace CSharpGeneral
{
    public class UsingStreams
    {
        private const string FILE_NAME = @"csharptest.txt";


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

        public static void PrintUnicode()
        {
            OutputEncoding = Encoding.UTF8;

            //for (int i = 0; i <= 65000; i++)
            //{
            //    var text = Encoding.UTF8.GetString(new byte[] { (byte) i });
            //    Write(text);
            //}

            //WriteLine(Encoding.GetEncoding()
        }
    }
}
