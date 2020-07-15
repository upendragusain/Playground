using CSharpGeneral.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpTests
{
    public class GenericsTests
    {
        [Fact]
        public void MultipleConstraintsOnAGenericType_Test()
        {
            Play.MultipleConstraintsOnAGenericType();
        }
    }
}
