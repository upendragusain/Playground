using System.Collections.Generic;

namespace CSharp6
{
    namespace auto_property_initializers
    {
        public class Employee2
        {
            public int Age { get; set; } = 35;
            public string Name { get; set; } = "Upendra";

            public ICollection<string> projects { get; } = 
                new List<string> { "project1" };

            private readonly ICollection<int> Numbers = 
                new List<int>();

            public void method(string x)
            {
                /*
                 * readonly collections can be updated but not re-assigned to!!
                 */
                //projects = new List<string>();
                projects.Add(x);
                Numbers.Add(2);
                //Numbers = new List<int>();
            }
        }
    }
}
