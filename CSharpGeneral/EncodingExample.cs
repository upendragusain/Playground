using System;
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
                string int_toBase2 = Convert.ToString((int)text[i],2);
                WriteLine($"'{text[i]}' => Unicode Code:  '\\u{(int)text[i]:x4}', Decimal: {(int)text[i]}, byte sequence: {int_toBase2}");
            }
        }

        public static void Base64EncodingAndBack(string text)
        {
            WriteLine($"Original text: {text}");
            byte[] text_toBytes = Encoding.UTF8.GetBytes(text, 0, text.Length);
            for (int i = 0; i < text_toBytes.Length; i++)
            {
                Write($"{text_toBytes[i]}\t");
            }
            WriteLine();
            var text_base64Encoded = Convert.ToBase64String(text_toBytes);
            WriteLine($"Base64 Encoded text: {text_base64Encoded}");

            byte[] base64EncodedBytes =
                Encoding.UTF8.GetBytes(text_base64Encoded, 0, text_base64Encoded.Length);
            for (int i = 0; i < base64EncodedBytes.Length; i++)
            {
                Write($"{base64EncodedBytes[i]}\t");
            }
        }
    }
}
