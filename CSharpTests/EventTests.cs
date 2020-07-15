using CSharpGeneral.DelegatesAndEvents;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpTests
{
    public class EventTests
    {
        [Fact]
        public void SimpleEvent()
        {
            EventExample ex = new EventExample();
            ex.Play();
        }

        [Fact]
        public void GenericInterfaceWithEvent()
        {
            Test t = new Test();
            t.DoSomething();
        }

        [Fact]
        public void ExplicitInterfaceImplementationWithPropertyAccessors_Test()
        {
            ExplicitInterfaceImplementationWithPropertyAccessors t = new ExplicitInterfaceImplementationWithPropertyAccessors();
            t.DoSomething();
        }
    }
}
