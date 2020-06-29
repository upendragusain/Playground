using System;

namespace CSharp7
{
    public class Employee
    {
        public static (string Name, int Age) Run()
        {
            return (Name: "Upendra", Age: 42);
        }

        public static void Run2()
        {
            (string a, int b, double c) bunchOfThings = ("a", 1, 10.9);

            Console.WriteLine($"{bunchOfThings.a}, " +
                $"{bunchOfThings.b}, {bunchOfThings.c}");
        }
    }
}
