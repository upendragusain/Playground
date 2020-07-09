using System;

namespace CSharpGeneral
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Equality.Run();


            //EncodingExample.Run();
            EncodingExample
                .PrintCharWithUnicodeCodePoint(
                ":upendra singh gusain?");

            EncodingExample
                .PrintCharWithUnicodeCodePoint(
                "你好");

            EncodingExample
                .PrintCharWithUnicodeCodePoint(
                "🐂");

            //UsingStreams.Run();

            Console.ReadLine();
        }
    }
}
