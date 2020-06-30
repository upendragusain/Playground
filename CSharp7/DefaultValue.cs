using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7
{
    public class DefaultValue
    {
        public static T DisplayDefault<T>()
        {
            return default(T);
        }
    }
}
