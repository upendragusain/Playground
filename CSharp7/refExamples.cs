using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7
{
    public class refExamples
    {
        public static void PassByRef(ref int id)
        {
            id = 42;
        }
    }
}
