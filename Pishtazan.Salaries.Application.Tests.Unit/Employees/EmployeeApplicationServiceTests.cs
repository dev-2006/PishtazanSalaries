using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.OvertimePolicies.Calculators.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees
{
    public class EmployeeApplicationServiceTests
    {
        IOvertimePolicyCalculatorFactory overtimePolicyFactory = new OvertimePolicyCalculatorFactory();
        IIncomeCalculationStrategy incomeCalculation = new IncomeCalculationStrategy();

        [Fact]
        public async void HandleCreateSalaryCommand_WhenEmployeeDosnotExist_CreatesNewEmployeeAndAddsSalaryToIt()
        {
            EmployeeRepositoryInMemory repository = new EmployeeRepositoryInMemory();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            await service.Handle(new CreateEmployeeSalary(new EmployeeSalary
            {
                FirstName = "ali", LastName = "ahmadi", Date = "14020305", BasicSalary = 1, Allowance = 2, Transportation = 3,
                OverTimeCalculator = "CalculatorA"
            }));

            Assert.Single(repository.Employees);
            Assert.Single(repository.Employees[0].Incomes);
        }
    }
}
