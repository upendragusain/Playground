using System;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Employee.Run();
            Console.WriteLine($"{result.Name}, {result.Age}");
            Employee.Run2();


            Console.ReadLine();
        }
    }
}
