using System;

namespace CSharp7
{
    public class ClassA
    {
        public string Name { get; set; }
    }

    struct structA
    {
        public int X { get; set; }
    }

    public class ClassB
    {
        public int Age { get; set; }
    }


    //https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching#the-is-type-pattern-expression
    /*
     * Pattern Matching constructs enable you to easily manage control flow among different variables and types 
     * that aren't related by an inheritance hierarchy.
     * Pattern Matching works with any data type. 
     * The default case is evaluated last, regardless of its textual order. 
     */
    public static class PatternMatching
    {
        public static string Match(object o)
        {
            switch (o)
            {
                case ClassA ca when ca.Name == "upendra":
                    return $"{nameof(ClassA)}.{ca.Name}";

                case ClassA ca:
                    return $"{nameof(ClassA)} no name supplied";

                case structA sa when sa.X < 10 && sa.X > 5:
                    return $"{nameof(structA)}.{sa.X}";

                case ClassB cb when cb.Age > 40:
                    return $"{nameof(structA)}.{cb.Age}";

                case null:
                    throw new ArgumentNullException("null value passed");

                default:
                    throw new ArgumentException("invalid input");
            }
        } 
    }
}
