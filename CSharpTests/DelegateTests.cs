using CSharpGeneral.DelegatesAndEvents;
using FluentAssertions;
using Xunit;

namespace CSharpTests
{
    public class DelegateTests
    {
        private readonly Play play;
        public DelegateTests()
        {
            play = new Play();
        }

        [Fact]
        public void SimpleDelegateCall()
        {
            var result = play.UseGreetDelegate();
            result.Should().Be("Hi, Upendra");
        }

        [Fact]
        public void PassDelegateAsParameter()
        {
            var result = play.UseDelegateAsParameter(MyMethod);
            result.Contains("Invoked").Should().Be(true);
        }

        private string MyMethod(string message)
        {
            return $"Invoked {nameof(MyMethod)}, received msg: {message}";
        }

        [Fact]
        public void MulticastDelegate()
        {
            play.MulticastDelegate();
        }

        [Fact]
        public void CallingDelegateWithOutParam()
        {
            var res = play.CallingDelegateWithOutParam(99);
            res.Should().Be(100);
        }

        [Fact]
        public void PredicateExample()
        {
            play.PredicateExample();
        }
    }
}
