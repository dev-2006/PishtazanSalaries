using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.Exceptions;
using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.Domain.Employees.Exceptions;
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
        const string OVER_TIME_CALCULATOR = "CalculatorA";

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
                OverTimeCalculator = OVER_TIME_CALCULATOR
            }));

            Assert.Single(repository.Employees);
            Assert.Single(repository.Employees[0].Incomes);
        }

        [Fact]
        public async void HandleCreateSalaryCommand_WhenEmployeeExistsAndNewSalaryDateIsNotInSameMonth_AddsSalaryToEmployeeIncome()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            await service.Handle(new CreateEmployeeSalary(new EmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.NOT_EXIST_SALARY_DATE_DIFFERENT_MONTH_STR,
                BasicSalary = 1, Allowance = 2, Transportation = 3, OverTimeCalculator = OVER_TIME_CALCULATOR
            }));

            Assert.Single(repository.Employees);
            Assert.Equal(2, repository.Employees[0].Incomes.Count);
        }

        [Fact]
        public async void HandleCreateSalaryCommand_WhenEmployeeExistsAndNewSalaryDateIsInSameMonth_ThrowsDuplicateSalariesInSameMonthException()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            var e = await Record.ExceptionAsync(() => service.Handle(new CreateEmployeeSalary(new EmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.NOT_EXIST_SALARY_DATE_SAME_MONTH_STR,
                BasicSalary = 1, Allowance = 2, Transportation = 3, OverTimeCalculator = OVER_TIME_CALCULATOR
            })));

            Assert.IsType<DuplicateSalariesInSameMonthException>(e);
        }

        [Fact]
        public async void HandleUpdateSalaryCommand_WhenEmployeeDoesnotExist_ThrowsEmployeeNotFoundException()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            var e = await Record.ExceptionAsync(() => service.Handle(new UpdateEmployeeSalary(new EmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.NOT_EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.NOT_EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.EXIST_SALARY_DATE_STR,
                BasicSalary = 1, Allowance = 2, Transportation = 3, OverTimeCalculator = OVER_TIME_CALCULATOR
            })));

            Assert.IsType<EmployeeNotFoundException>(e);
        }

        [Fact]
        public async void HandleUpdateSalaryCommand_WhenEmployeeExistsButSalaryInSameMonthDoesnotExist_ThrowsSalaryInSameMonthNotFoundException()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            var e = await Record.ExceptionAsync(() => service.Handle(new UpdateEmployeeSalary(new EmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.NOT_EXIST_SALARY_DATE_DIFFERENT_MONTH_STR,
                BasicSalary = 1, Allowance = 2, Transportation = 3, OverTimeCalculator = OVER_TIME_CALCULATOR
            })));

            Assert.IsType<SalaryInSameMonthNotFoundException>(e);
        }

        [Fact]
        public async void HandleUpdateSalaryCommand_WhenEmployeeExistsAndSalaryInSameMonthExists_ReplacesSalary()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            await service.Handle(new UpdateEmployeeSalary(new EmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.NOT_EXIST_SALARY_DATE_SAME_MONTH_STR,
                BasicSalary = 11, Allowance = 21, Transportation = 31, OverTimeCalculator = OVER_TIME_CALCULATOR
            }));

            Assert.Single(repository.Employees);
            Assert.Single(repository.Employees[0].Incomes);
            Assert.Equal(repository.Employees[0].Incomes.First().Date, EmployeeRepositoryBuilder.NOT_EXIST_SALARY_DATE_SAME_MONTH);
            Assert.Equal(repository.Employees[0].Incomes.First().SalaryDetails.BasicSalary, new BasicSalary(11));
        }

        [Fact]
        public async void HandleDeleteSalaryCommand_WhenEmployeeDoesnotExist_EmployeeNotFoundException()
        {
            EmployeeRepositoryInMemory repository = EmployeeRepositoryBuilder.CreateRepositoryWithOneEmployeeAndOneSalary();

            EmployeeApplicationService service = new EmployeeApplicationService(repository, incomeCalculation, overtimePolicyFactory);

            var e = await Record.ExceptionAsync(() => service.Handle(new DeleteEmployeeSalary
            {
                FirstName = EmployeeRepositoryBuilder.NOT_EXIST_EMP_FN,
                LastName = EmployeeRepositoryBuilder.NOT_EXIST_EMP_LN,
                Date = EmployeeRepositoryBuilder.EXIST_SALARY_DATE_STR,
            }));

            Assert.IsType<EmployeeNotFoundException>(e);
        }
    }
}
