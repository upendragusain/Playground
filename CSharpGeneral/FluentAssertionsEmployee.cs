using System;
using System.Collections.Generic;
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
    }
}
