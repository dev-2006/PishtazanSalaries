using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees
{
    public class IncomeDetailTests
    {
        [Fact]
        public void Constructor_NullDate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IncomeDetail(date: null!, 
                new SalaryDetail(new BasicSalary(1), new Allowance(1), new Transportation(1)), new Income(1)));
        }

        [Fact]
        public void Constructor_NullSalaryDetail_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IncomeDetail(Date.FromString("14000101"),
               salaryDetails: null!, new Income(1)));
        }

        [Fact]
        public void Constructor_NullIncome_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IncomeDetail(Date.FromString("14000101"),
                new SalaryDetail(new BasicSalary(1), new Allowance(1), new Transportation(1)), income: null!));
        }
    }
}
