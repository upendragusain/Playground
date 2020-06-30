using System;

namespace CSharp8
{
    public class PatternMatching
    {
        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        public static RGBColor SwitchExpression(Rainbow colorBand) =>
        colorBand switch
        {
            Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
            Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
            Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
            Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
            Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
            Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
            Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };

        public static string TuplePatters(string name, int age)
            => (name, age) switch
            {
                ("Ned Stark", 45) => "Long live the slayed king",
                ("Jon Snow", 24) => "Knows nothing",
                ("Sansa stark", 19) => "poor child",
                ("Tyrion", 28) => "the pimp",
                ("Jammie", 30) => "the king slayer",
                (_,_) => "George R R Martin"
            };
    }

    public class RGBColor
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public RGBColor(int red, int green, int blue)
        {
            Red = red;
            Blue = blue;
            Green = green;
        }
    }
}
