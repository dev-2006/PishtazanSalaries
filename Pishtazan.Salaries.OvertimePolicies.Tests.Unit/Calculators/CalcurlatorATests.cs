using Pishtazan.Salaries.Domain.Employees.Salaries;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.OvertimePolicies.Tests.Unit.Calculators
{
    public class CalcurlatorATests
    {
        [Fact]
        public void Calculate_NullBasicSalary_ThrowsArgumentNullExcpetion()
        {
            Assert.Throws<ArgumentNullException>(() => new CalculatorA().Calculate(null!, new Allowance(1)));
        }

        [Fact]
        public void Calculate_NullAllowance_ThrowsArgumentNullExcpetion()
        {
            Assert.Throws<ArgumentNullException>(() => new CalculatorA().Calculate(new BasicSalary(1), null!));
        }

        [Theory]
        [InlineData(1L, 2L, 3L)]
        [InlineData(12L, 13L, 25L)]
        public void Calculate_NotNullArguments_ReturnsSumOfArguments(long basicSalaryAmount, long allowanceAmount, long sum)
        {
            Assert.Equal(new Salary(sum), new CalculatorA().Calculate(new BasicSalary(basicSalaryAmount), new Allowance(allowanceAmount)));
        }
    }
}
