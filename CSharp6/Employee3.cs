namespace CSharp6
{
    namespace expression_bodied_function_members
    {
        public class Employee3
        {
            public override string ToString() => $"upendra gusain";

            //https://twitter.com/bevatanmusafir/status/1277549792936243200?s=20
            public int Age1 => 39;
            public int Age2 { get; }

            private readonly int Age3;

            const int Age4 = 42;

            public Employee3()
            {
                // can't even be initialized in the ctor
                //Age1 = 40;
                Age2 = 41;
                Age3 = 42;
                //Age4 = 8;
            }

            //public void method(int age)
            //{
            //    Age1 = age;
            //    Age2 = age;
            //}
        }
    }
}
