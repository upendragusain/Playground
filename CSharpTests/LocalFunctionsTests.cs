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
    }
}
