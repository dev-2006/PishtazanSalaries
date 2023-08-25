using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees
{
    public class EmployeeTests
    {
        [Fact]
        public void Constructor_NullFullName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(fullName: null!, incomes: new List<IncomeDetail>()));
        }

        [Fact]
        public void Constructor_NullIncomes_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes: null!));
        }
    }
}
