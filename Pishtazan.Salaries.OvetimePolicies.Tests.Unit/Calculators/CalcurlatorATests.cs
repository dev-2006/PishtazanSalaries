using Pishtazan.Salaries.Domain.Employees.Salaries;
using Pishtazan.Salaries.OvetimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.OvetimePolicies.Tests.Unit.Calculators
{
    public class CalcurlatorATests
    {
        [Fact]
        public void Calculate_NullBasicSalary_ThrowsArgumentNullExcpetion()
        {
            Assert.Throws<ArgumentNullException>(() => new CalcurlatorA().Calculate(null!, new Allowance(1)));
        }
    }
}
