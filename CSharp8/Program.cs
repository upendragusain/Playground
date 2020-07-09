using System;
using System.Threading.Tasks;

namespace CSharp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await AsyncStreams.Run();

            //Generics.Run2();

            //xmlSerialization.XMLWrite.WriteXML();

            //struct_with_interface.StructWithInterface.Run();

            //type_conversion.Test.Run();

            StringEscapeSequences();

            Console.ReadLine();
        }

        public static void StringEscapeSequences()
        {
            Console.WriteLine($"He said, \"Upendra!\".");
            Console.WriteLine($"c:\\folder\\file.txt");
            Console.WriteLine($"My\tname\tis\tUpendra");
            Console.Write($"My\vname\vis\vUpendra");
        }
    }
}
