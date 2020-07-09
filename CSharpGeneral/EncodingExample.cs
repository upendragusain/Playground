using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharpGeneral
{
    public class EncodingExample
    {
        public static void Run()
        {
            OutputEncoding = Encoding.UTF8;

            //The value of a Char object is its 16-bit numeric (ordinal) value.
            char a = '\u00e4';
            WriteLine($"Unicode Code Unit/Point '\\u00e4': {a}");
            WriteLine($"Unicode Code Unit/Point of a combining character'\\u0061' followed by '\\u0308': {a}");

            WriteLine($"{(int)char.MinValue} - {(int)char.MaxValue}");

            WriteLine($"'a' : {Convert.ToUInt16('a')}");
            WriteLine($"'A' : {Convert.ToUInt16('A')}");
            WriteLine($"'?' : {Convert.ToUInt16('?')}");

        }

        public static void PrintCharWithUnicodeCodePoint(string text)
        {
            //UTF-16 isn't availabl as that's what .NET uses to encode string instances by default
            OutputEncoding = Encoding.UTF8;
            for (int i = 0; i < text.Length; i++)
            {
                // :x4 => hex with 4 length padded
                WriteLine($"'{text[i]}' => Unicode Code:  '\\u{(int)text[i]:x4}', Decimal: {(int)text[i]}");
            }
        }
    }
}
