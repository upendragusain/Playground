using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp7;
using Xunit;
using static CSharp7.Library;

namespace CSharpTests
{
    public class RefTests
    {
        [Fact]
        public void PassByRef_updates_value()
        {
            int i = 10;
            RefExamples.PassByRef(ref i);

            Assert.Equal(42, i);
        }

        [Fact]
        public void Reference_Return_Value_test()
        {
            var array = new[] { 1, 34, 5, 78, 90, 1, 99, 100, 3, 108 };
            ref var answer = ref RefExamples.FindLargest(array);

            Assert.True(answer == 108);
        }

        [Fact]
        public void RefReadonly_test()
        {
            var array = new[] { 100, 34, 5, 78, 90, 1, 99, 100, 3, 108 };
            ref readonly int x =  ref RefExamples.RefReadonly(array);

            // can't do this , compile error
            //x++;
            Assert.True(x == 100);
        }

        [Fact]
        public void Library_test()
        {
            var lib = new Library();
            var oldBooks = lib.ListBooks();

            ref Book book = ref lib.GetABookThatCanBeReplaced("Call of the Wild, The");
            book = new Book() { Title = "C# 7" };
            var newBooks = lib.ListBooks();

            Assert.True(newBooks.Where(_ => _.Title == "Call of the Wild, The").FirstOrDefault() == null);
            Assert.Single(newBooks.Where(_ => _.Title == "C# 7"));
        }
    }
}
