using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharpGeneral.Generics
{
    public class Play
    {
        public static void MultipleConstraintsOnAGenericType()
        {
            EmployeeList<PartTimer> partTiers = new EmployeeList<PartTimer>();
        }

        public static string ConstrainingMultipleParameters()
        {
            var merger = new MergeSpecies<Lion, John>();
            return merger.Merge(new Lion(), new John());
        }
    }

    public class EmployeeList<T> where T : Employee, IEmployee, IComparable<T>, new()
    {
    }

    public interface IEmployee
    {
        string Do();
    }

    public class Employee
    {
        public virtual string DoWork()
        {
            return "Done";
        }
    }

    public class PartTimer : Employee, IEmployee, IComparable<PartTimer>
    {
        public int Experience { get; set; }

        //uncommenting the below will not compile as then no more public parameterless ctor fpr the constraint
        //public PartTimer(int id)
        //{

        //}

        public override string DoWork()
        {
            return $"{nameof(PartTimer)}.{nameof(DoWork)}-Done";
        }

        public int CompareTo([AllowNull] PartTimer other)
        {
            return other.Experience > this.Experience ? 1 : 0;
        }

        public string Do()
        {
            return "Did";
        }
    }

    public class MergeSpecies<T, U> 
        where T: Mammal, new() 
        where U : Human, new()
    {
        public string Merge(T mammal, U human)
        {
            return mammal.GetGeneticCode() + human.GetGeneticCode();
        }
    }

    public abstract class Human
    {
        public abstract string GetGeneticCode();
        
    }

    public class John : Human
    {
        public override string GetGeneticCode()
        {
            return "johnjohnjohn";
        }
    }

    public abstract class Mammal
    {
        public abstract string GetGeneticCode();
    }

    public class Lion : Mammal
    {
        public override string GetGeneticCode()
        {
            return "lionlionlion";
        }
    }

    public class CLassA
    {
        // error as T can't be inferred
        //public void Do(T a)
        public void Do<T>(T a) //either make the method generic ver T or the class itself generic over T
        {

        }
    }

    public interface IMonth<T> 
    {
        T Get(T t);
    }

    // implementing clases will get a closed constructed (over int) 
    // get method plus GetFeb  method with the type of their choice
    public interface IFeb<T> : IMonth<int>
    {
        T GetFeb(T t);
    }

    public class A : IFeb<string>
    {
        public int Get(int t)
        {
            throw new NotImplementedException();
        }

        public string GetFeb(string t)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExist 
    {
        string IAm();
    }

    // out = return = covariance =  may return more derived type is default
    // in = accept = contravariance = may acccept a less derived type
    public interface ITooExist<out T>: IExist 
    {
        T ITooAm();
    }
    public class Existence : ITooExist<int>
    {
        public string IAm()
        {
            throw new NotImplementedException();
        }

        public int ITooAm()
        {
            throw new NotImplementedException();
        }
    }

    public class GenericList<T>
    {
        /*
         * If you define a generic method that takes the same type parameters as the containing class, the compiler generates warning CS0693 because within the method scope, the argument supplied for the inner T hides the argument supplied for the outer T.
         * also notice constraints at method level!
         */
        public void Method<T>() where T : new()
        {
        }

        // providing another identifier for the type parameter of the method
        // so as not to hide
        public void Method2<U>()
        {
            
        }
    }

    public class ConcreteList
    {
        public static void InnerTypeHidesOuterType()
        {
            var x = new GenericList<int>();
            x.Method<A>();

            x.Method2<string>();
        } 

        class A
        {

        }
    }

}
