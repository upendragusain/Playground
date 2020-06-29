using System;
using System.Collections.Generic;
using System.Text;
using CSharp7;
using Xunit;

namespace CSharpTests
{
    public class RefTests
    {
        [Fact]
        public void PassByRef_updates_value()
        {
            int i = 10;
            refExamples.PassByRef(ref i);

            Assert.Equal(42, i);
        }
    }
}
