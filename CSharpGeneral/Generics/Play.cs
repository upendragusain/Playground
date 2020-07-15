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
}
