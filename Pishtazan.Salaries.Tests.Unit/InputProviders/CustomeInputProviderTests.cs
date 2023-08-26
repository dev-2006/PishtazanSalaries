using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.InputProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Tests.Unit.InputProviders
{
    public class CustomeInputProviderTests
    {
        [Fact]
        public void Convert_ValidInput_CreatesEmployeeSalaryObject()
        {
            CustomeInputProvider inputProvider = new CustomeInputProvider();
            EmployeeSalary salary = inputProvider.Convert("FirstName/LastName/BasicSalary/Allowance/Transportation/Date\r\nAli/Ahmadi/1200000/400000/350000/14010801");

            Assert.NotNull(salary);
            Assert.Equal("Ali", salary.FirstName);
            Assert.Equal("Ahmadi", salary.LastName);
            Assert.Equal(1200000L, salary.BasicSalary);
            Assert.Equal(400000L, salary.Allowance);
            Assert.Equal(350000L, salary.Transportation);
            Assert.Equal("14010801", salary.Date);
        }
    }
}
