using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGeneral
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Equality
    {
        public static void Run()
        {
            var s1 = new Student();
            var s2 = new Student()
            {
                Id = 1,
                Name = "A"
            };

            Student s3 = null;

            //Console.WriteLine(ReferenceEquals(s1, s2));
            //Console.WriteLine(ReferenceEquals(s1, s3));
            //Console.WriteLine(ReferenceEquals(s2, s3));

            //Console.WriteLine(ReferenceEquals(s1, s1));
            //Console.WriteLine(ReferenceEquals(s2, s2));
            //Console.WriteLine(ReferenceEquals(s3, s3));

            //Console.WriteLine(s1.Equals(s1));
            //Console.WriteLine(s1.Equals(s2));
            //Console.WriteLine(s1.Equals(s3));

            //Console.WriteLine(s2.Equals(s3));

            //Console.WriteLine(s1 == s1);
            //Console.WriteLine(s2 == s2);
            //Console.WriteLine(s3 == s3);

            //Console.WriteLine(s1 == s2);
            //Console.WriteLine(s1 == s3);
            //Console.WriteLine(s2 == s3);

            var s4 = new Student()
            {
                Id = 1,
                Name = "A"
            };

            Console.WriteLine(ReferenceEquals(s2, s4));
            //.Equals checks data equality for value types, and reference equality for non-value types (general objects).
            Console.WriteLine(s2.Equals(s4));
            Console.WriteLine(s4.Equals(s2));

        }
    }
}
