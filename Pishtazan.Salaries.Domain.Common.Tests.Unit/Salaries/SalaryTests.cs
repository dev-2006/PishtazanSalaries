using Pishtazan.Salaries.Domain.Common;
using Pishtazan.Salaries.Domain.Common.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common.Tests.Unit.Salaries
{
    public class SalaryTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5)]
        public void Constructor_TooFewSalaryAmount_ThrowsArgumentOutOfRangeException(long amount)
        {
            var e = Record.Exception(() => new Salary(amount));

            Assert.IsType<ArgumentOutOfRangeException>(e);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(50)]
        public void Constructor_ValidSalaryAmount_CreatesSalaryWithEqualValue(long amount)
        {
            var s = new Salary(amount);

            Assert.Equal(amount, s.Value);
        }

        [Fact]
        public void DiffrentNameObjectWithSameValueAreEqual()
        {
            var salary1 = new Salary(20);
            var salary2 = new Salary(20);

            Assert.Equal(salary1, salary2);
            Assert.True(salary1 == salary2);
            Assert.False(ReferenceEquals(salary1, salary2));
        }

        [Fact]
        public void Add_TwoSalaries_ReturnsNewSalaryWithSumOfSalariesAmount()
        {
            Salary s1 = new Salary(20);
            Salary s2 = new Salary(15);

            Salary sum = new Salary(35);

            Assert.Equal(sum, s1.Add(s2));
        }

        [Fact]
        public void PlusOperator_TwoSalaries_ReturnsNewSalaryWithSumOfSalariesAmount()
        {
            Salary s1 = new Salary(12);
            Salary s2 = new Salary(7);

            Salary sum = new Salary(19);

            Assert.Equal(sum, s1 + s2);
        }
    }
}
