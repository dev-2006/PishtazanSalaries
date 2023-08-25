﻿using Pishtazan.Salaries.Domain.Common;
using Pishtazan.Salaries.Domain.Employees.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees.Salaries
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
    }
}
