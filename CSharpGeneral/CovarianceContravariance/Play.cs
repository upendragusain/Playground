using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharpGeneral.CovarianceContravariance
{
    public class Play
    {
        public static void MethodA(IEnumerable<object> objects)
        {
            foreach (var item in objects)
            {
                Console.WriteLine(item.GetType());
            }
        }

        public static void DoSomething()
        {
            var x = new List<string>() { "a", "x", "word" };
            MethodA(x);
        }

        //IEnumerable is declared with 'out' hence covariant
        public static void CovarianceAssignment()
        {
            IEnumerable<string> strings = new List<string>();

            // more derived types can be assigned to less derived types
            IEnumerable<object> objects = strings;
            IEnumerable<object> objects2 = new List<A>();

            // *** Value types do not support variance.
            IEnumerable<int> ints = new List<int>();
            //IEnumerable<object> wontwork = ints;

            // *** It is also important to remember that classes that implement variant interfaces are still invariant.
            //List<object> willNotWorkAsListClassIsNotVariant = new List<string>();
            IEnumerable<object> works_fine_since_not_a_class_but_IEnumerable_Interface = 
                new List<string>();
        }

        //Action is declared with 'in' hence contravariant
        public static void ContravarianceAssignment()
        {
            Action<object> actionObject =
                (object o) =>
            {
                Console.WriteLine(o.GetType());
                Console.WriteLine(o.ToString());
            };

            Action<string> actionString = actionObject;
            actionString("sending a string");

            Action<A> actionInt = actionObject;
            actionInt(new A());
        }

        public static void ContraVarianceInInterfaces()
        {
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();
            var res1 = baseComparer.Equals(
                new BaseClass(1), new BaseClass(1));

            // you can use the baseclass comparer t also compare the derived class
            // the equals method recieves a derived class type
            // IEqualityComparer is declared with 'in' hence is contraVariant
            IEqualityComparer<DerivedClass> derivedComparer = baseComparer;
            var res2 = derivedComparer.Equals(
                new DerivedClass(103, "xxx"), new DerivedClass(103, "yyy"));
        }
    }

    internal class A
    {
    }

    public class BaseClass
    {
        public int Id { get; }
        public BaseClass(int id)
        {
            Id = id;
        }
    }
    public class DerivedClass : BaseClass
    {
        public string Name { get; }
        public DerivedClass(int id, string name) : base(id)
        {
            Name = name;
        }
    }

    public class BaseComparer : IEqualityComparer<BaseClass>
    {
        // IComparer
        //public int Compare([AllowNull] BaseClass x, [AllowNull] BaseClass y)
        //{
        //    throw new NotImplementedException();
        //}

        // IComparable
        //public int CompareTo([AllowNull] BaseClass other)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Equals([AllowNull] BaseClass x, [AllowNull] BaseClass y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] BaseClass obj)
        {
            return obj.GetHashCode();
        }
    }

    public interface ICovariant<out T>
    {
        T Get();

        // *** compile error, as covariance is about returning the same type and not accepting the same type
        // either make this interface invariant by removing the 'out'
        // or make this interface both co and contra variant by using in and out but for separate methods!!!
        //void Set(T t);
    }

    public interface IContraVariant<in T>
    {
        void Set(T t);

        // *** same compile error as above
        // if contra variant then the same type must be asked for as a parameter and and must not return the same type
        //T Get();
    }

    public interface BothCoAndContravariant<out T, in U>
    {
        T Get();

        void Set(U u);
    }
}
