using Pishtazan.Salaries.Application.Employees.Contracts.Command;
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

        public Task Handle(object command)
        {
            throw new NotImplementedException();
        }
    }

}
