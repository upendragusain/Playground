using CSharp7;
using System;
using Xunit;

namespace CSharpTests
{
    public class PatternMatchingTests
    {
        [Fact]
        public void ClassA_With_Name_IsMatched()
        {
            var x = new ClassA();
            x.Name = "upendra";
            var result = PatternMatching.Match(x);

            Assert.True(result == "ClassA.upendra");
        }

        [Fact]
        public void Null_IsMatched()
        {
            Assert.Throws<ArgumentNullException>(() => 
            PatternMatching.Match(null));
        }

        [Fact]
        public void Invalid_Argument_IsMatched()
        {
            Assert.Throws<ArgumentException>(() =>
            PatternMatching.Match(100));
        }
    }
}
