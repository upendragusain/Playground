using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CSharpGeneral
{
    public class FluentAssertionsEmployee
    {
        public string Name { get; }
        public DateTime DateOfBirth { get; }

        private readonly List<string> Achievements;


        public FluentAssertionsEmployee(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public int GetRemainingLeaves(int month)
        {
            return (12 - month) * 2;
        }

        public void GetShot()
        {
            throw new EmployeeRightsViolationException("Employees may not be shot");
        }
    }

    [Serializable]
    public class EmployeeRightsViolationException : Exception
    {
        public EmployeeRightsViolationException()
        {
        }

        public EmployeeRightsViolationException(string message) : base(message)
        {
        }

        public EmployeeRightsViolationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeRightsViolationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
