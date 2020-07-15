using System;

namespace CSharpGeneral.DelegatesAndEvents
{
    /*
     * Action, Func and Predicate (Represents the method that defines a set of criteria and determines whether the specified object meets those criteria.) John went home (subject+ predicate(went home))
       All these delegate type definitions in the .NET Core Library should mean that you do not need to define a new delegate type for any new feature you create that requires delegates. These generic definitions should provide all the delegate types you need under most situations. You can simply instantiate one of these types with the required type parameters. In the case of algorithms that can be made generic, these delegates can be used as generic types.
     */
    public class Play
    {
        public delegate string MyDelegate(string name);

        public delegate void DelegateWithOutParam(out int i);

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

            MyDelegate del4 = Play.StaticMethod;

            var del4_res = del4("invoking static method");

        }

        public static string StaticMethod(string message)
        {
            return message;
        }

        public int CallingDelegateWithOutParam(int i)
        {
            DelegateWithOutParam del = SetNumber;
            del(out i);
            return i;
        }

        private void SetNumber(out int i)
        {
            i = 100;
        }

        //Represents the method that defines a set of criteria and determines whether the specified object meets those criteria.
        //public delegate bool Predicate<in T>(T obj);
        public void PredicateExample()
        {
            Predicate<int> isEven = (i) => { return i % 2 == 0; };

            var res = isEven(11);
            var res2 = isEven(12);

            var i = 1;
            var res3 = localMethod(i, i => i >= 10);

            bool localMethod(int i, Predicate<int> condition)
            {
                return condition(i);
            }
        }
    }
}
