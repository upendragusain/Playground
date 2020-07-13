using CSharpGeneral;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CSharpTests
{
    public class FluentAssertionsEmployeeShould: IClassFixture<FluentAssertionsEmployeeFixture>
    {
        private readonly FluentAssertionsEmployeeFixture _fixture;

        public FluentAssertionsEmployeeShould(FluentAssertionsEmployeeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void SetEmployeeName()
        {
            FluentAssertionsEmployee employee =
                _fixture.Employee;

            employee.Name.Should()
                .Be("Upendra", because: "That's what my parents named me!");
            employee.DateOfBirth.Should()
                .Be(new DateTime(1913, 3, 23), because: "believe it or not, I am very very old!");
        }

        [Theory]
        [MemberData(nameof(EmployeesData.Data), MemberType = typeof(EmployeesData))]
        public void SetEmployeeNames(string name, DateTime dob)
        {
            FluentAssertionsEmployee employee =
               new FluentAssertionsEmployee(name, dob);

            employee.Name.Should()
                .Be(name, because: "That's what my parents named me!");
            employee.DateOfBirth.Should()
                .Be(dob, because: "believe it or not, I am very very old!");
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void GetRemainingLeaves(int month)
        {
            FluentAssertionsEmployee employee =
                new FluentAssertionsEmployee("", DateTime.Now);

            employee.GetRemainingLeaves(month).Should()
                .Be((12 - month) * 2);
        }
    }

    public class FluentAssertionsEmployeeFixture
    {
        public readonly FluentAssertionsEmployee Employee;
        public FluentAssertionsEmployeeFixture()
        {
            Employee = new FluentAssertionsEmployee("Upendra", new DateTime(1913, 3, 23));
        }
    }

    public class EmployeesData
    {
        public static IEnumerable<object[]> Data
        {
            get
            {
                yield return new object[] {"Jon snow", new DateTime(1976, 2, 19) };
                yield return new object[] { "Tyrion Lanister", new DateTime(1967, 12, 1) };
            }
        }
    }
}
