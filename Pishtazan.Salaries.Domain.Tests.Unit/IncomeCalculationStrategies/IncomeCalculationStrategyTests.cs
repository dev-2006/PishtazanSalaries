using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.IncomeCalculationStrategies
{
    public class IncomeCalculationStrategyTests
    {
        IncomeCalculationStrategy startegy = new IncomeCalculationStrategy();

        [Fact]
        public void Calculate_NullSalaryDetail_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => startegy.Calculate(null!, new CalculatorA()));
        }

        [Fact]
        public void Calculate_NullOvertimeCalculator_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => startegy.Calculate(
                new SalaryDetail(new BasicSalary(1), new Allowance(1), new Transportation(1)), null!));
        }
    }
}
