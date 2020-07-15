using CSharpGeneral.Generics;
using FluentAssertions;
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

        [Fact]
        public void ConstrainingMultipleParameters_Test()
        {
            Play.ConstrainingMultipleParameters()
                .Should()
                .Be("lionlionlionjohnjohnjohn");
        }
    }
}
