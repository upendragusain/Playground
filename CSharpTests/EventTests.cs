using CSharpGeneral.Delegates;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpTests
{
    public class EventTests
    {
        [Fact]
        public void Test1()
        {
            EventExample ex = new EventExample();
            ex.Play();
        }
    }
}
