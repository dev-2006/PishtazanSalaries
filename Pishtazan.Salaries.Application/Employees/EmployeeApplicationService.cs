using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.Exceptions;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.Infrastructure.Validation;
using Pishtazan.Salaries.OvertimePolicies.Calculators.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees
{
    public class EmployeeApplicationService : IApplicationService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IIncomeCalculationStrategy _incomeCalculation;
        private readonly IOvertimePolicyCalculatorFactory _overtimePolicyFactory;

        public EmployeeApplicationService(IEmployeeRepository repository, IIncomeCalculationStrategy incomeCalculation,
            IOvertimePolicyCalculatorFactory overtimePolicyFactory)
        {
            _repository = Validate.ArgumentNotNull(repository, nameof(repository));
            _incomeCalculation = Validate.ArgumentNotNull(incomeCalculation, nameof(incomeCalculation));
            _overtimePolicyFactory = Validate.ArgumentNotNull(overtimePolicyFactory, nameof(overtimePolicyFactory));
        }

        public Task Handle(object command) =>
            command switch
            {
                CreateEmployeeSalary cmd => createSalary(cmd),
                UpdateEmployeeSalary cmd => updateSalary(cmd),
                DeleteEmployeeSalary cmd => deleteSalary(cmd),

                _ => throw new InvalidOperationException("undefined command")
            };

        private async Task createSalary(CreateEmployeeSalary cmd)
        {
            FullName fullName = FullNameFrom(cmd);

            var employee = await _repository.Load(fullName);

            if (employee == null)
            {
                employee = new Employee(fullName);
                await _repository.Add(employee);
            }

            employee.AddIncome(DateFrom(cmd), SalaryDetailFrom(cmd), _incomeCalculation,
                _overtimePolicyFactory.Get(cmd.OverTimeCalculator!));

            await _repository.SaveChanges();
        }

        private static FullName FullNameFrom(EmployeeSalary cmd)
        {
            return new FullName(new FirstName(cmd.FirstName!), new LastName(cmd.LastName!));
        }

        private static Date DateFrom(EmployeeSalary cmd)
        {
            return Date.FromString(cmd.Date!);
        }

        private static SalaryDetail SalaryDetailFrom(EmployeeSalary cmd)
        {
            return new SalaryDetail(new BasicSalary(cmd.BasicSalary!.Value), new Allowance(cmd.Allowance!.Value), 
                new Transportation(cmd.Transportation!.Value));
        }

        private async Task updateSalary(UpdateEmployeeSalary cmd)
        {
            FullName fullName = FullNameFrom(cmd);

            var employee = await _repository.Load(fullName);

            if (employee == null)
                throw new EmployeeNotFoundException();

            employee.UpdateIncome(DateFrom(cmd), SalaryDetailFrom(cmd), _incomeCalculation,
                _overtimePolicyFactory.Get(cmd.OverTimeCalculator!));
        }

        private async Task deleteSalary(DeleteEmployeeSalary cmd)
        {
            FullName fullName = FullNameFrom(cmd);

            var employee = await _repository.Load(fullName);

            if (employee == null)
                throw new EmployeeNotFoundException();

            employee.DeleteIncome(Date.FromString(cmd.Date!));
        }

        private static FullName FullNameFrom(DeleteEmployeeSalary cmd)
        {
            return new FullName(new FirstName(cmd.FirstName!), new LastName(cmd.LastName!));
        }
    }

}
