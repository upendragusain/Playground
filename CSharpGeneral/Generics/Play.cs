using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharpGeneral.Generics
{
    public class Play
    {
        public static void MultipleConstraintsOnAGenericType()
        {
            EmployeeList<PartTimer> partTiers = new EmployeeList<PartTimer>();
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
}
