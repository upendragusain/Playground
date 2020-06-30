using CSharpGeneral;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace CSharpTests
{
    public class LocalFunctionsTests
    {
        [Fact]
        public void WithoutLocalFunctionTest()
        {
            IEnumerable<int> oddNumbers = LocalFunctions.OddSequence(10, 109);

            /*
             * (w/o local functions) For method iterators, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved.
             */
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                foreach (var item in oddNumbers)
                {
                    Debug.Print(item.ToString());
                }
            });
        }

        [Fact]
        public void WithLocalFunctionTest()
        {
            /*
             * One of the useful features of local functions is that they can allow exceptions to surface immediately.
             */
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IEnumerable<int> oddNumbers = LocalFunctions.OddSequenceWithLocalFunction(10, 109);
            });
        }

        [Fact]
        public void WithOutLocalFunctionAsyncTest()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var result = LocalFunctions.DownloadPage("x").Result;
            });
        }

        [Fact]
        public void WithLocalFunctionAsyncTest()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var result = LocalFunctions.DownloadPageWithLocalFunction("x").Result;
            });
        }

        [Fact]
        public void GetFactorialTest()
        {
            var fact0 = LocalFunctions.GetFactorial(0);
            Assert.Equal(1, fact0);

            var fact1 = LocalFunctions.GetFactorial(1);
            Assert.Equal(1, fact1);

            var fact2 = LocalFunctions.GetFactorial(2);
            Assert.Equal(2, fact2);

            var fact10 = LocalFunctions.GetFactorial(10);
            Assert.Equal(3628800, fact10);

            long fact13 = LocalFunctions.GetFactorial(13);
            Assert.Equal(6227020800, fact13);
        }
    }
}
