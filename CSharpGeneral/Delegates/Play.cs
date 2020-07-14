using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSharpGeneral.Delegates
{
    public class Play
    {
        public delegate string MyDelegate(string name);

        public string UseGreetDelegate()
        {
            MyDelegate myDelegate = SayHi;
            return myDelegate("Upendra");
        }

        public string SayHi(string name)
        {
            return $"Hi, {name}";
        }

        public string SayBye(string name)
        {
            return $"Bye, {name}";
        }

        public string UseDelegateAsParameter(MyDelegate del)
        {
            return del("I am a message from a delegate passed as a parameter!");
        }

        public void MulticastDelegate()
        {
            MyDelegate myMulticastDelegate = SayHi;
            myMulticastDelegate += SayBye;

            MyDelegate anonDelegate = (v) => { return v; };

            MyDelegate del3 = myMulticastDelegate + anonDelegate;

            var res = myMulticastDelegate("Jon Snow");

            var res2 = anonDelegate("anonymous method delegate");

            var res3 = del3("call all in added sequence, the result will be the result of last method invocation");

            var length = del3.GetInvocationList().Length;
        }
    }
}
