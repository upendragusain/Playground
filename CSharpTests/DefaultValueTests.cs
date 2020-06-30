using CSharp7;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpTests
{
    public class DefaultValueTests
    {
        [Fact]
        public void DisplayDefaultTest()
        {
            var val = DefaultValue.DisplayDefault<int>();
            Assert.Equal(0, val);

            var val2 = DefaultValue.DisplayDefault<int?>();
            Assert.Null(val2);

            var val3 = DefaultValue.DisplayDefault<string>();
            Assert.Null(val3);

            var val4 = DefaultValue.DisplayDefault<object>();
            Assert.Null(val4);

            var val5 = DefaultValue.DisplayDefault<List<int>>();
            Assert.Null(val5);
        }
    }
}
