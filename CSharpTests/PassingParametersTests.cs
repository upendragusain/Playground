using CSharpGeneral;
using Xunit;

namespace CSharpTests
{
    public class PassingParametersTests
    {
        [Fact]
        public void passby_val_vs_ref()
        {
            int i = 5;
            int j = 10;
            PassingParameters.SquareItByVal(i);
            PassingParameters.SquareItByRef(ref j);
            Assert.Equal(5, i);
            Assert.Equal(100, j);
        }

        [Fact]
        public void PassingRefTypesByValue_test()
        {
            int[] array = new[] { 1, 2, 4, 5 };
            PassingParameters.PassingRefTypesByValue(array);
            Assert.True(array[0] == 42);
        }

        [Fact]
        public void PassingRefTypesByRef_test()
        {
            int[] array = new[] { 1, 2, 4, 5 };
            PassingParameters.PassingRefTypesByRef(ref array);
            Assert.True(array[0] == 69);
            Assert.True(array.Length == 1);
        }
    }
}
