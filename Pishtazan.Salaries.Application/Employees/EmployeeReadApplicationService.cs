using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.Application.Employees.Exceptions;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.OvertimePolicies.Calculators.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Application.Employees
{
    public class EmployeeReadApplicationService : IEmployeeReadApplicationService
    {
        private readonly IEmployeeReadRepository _repository;

        public EmployeeReadApplicationService(IEmployeeReadRepository repository)
        {
            _repository = ArgumentNotNull(repository, nameof(repository));
        }

        public Task<IncomeDetailDTO?> Query(GetEmployeeSalaryInExactDate query)
        {
            ArgumentNotNull(query, nameof(query));

            return _repository.Query(new FullName(new FirstName(query.FirstName!), new LastName(query.LastName!)),
                Date.FromString(query.Date!));
        }

        public Task<IEnumerable<IncomeDetailDTO>?> Query(GetEmployeeSalariesInDateRange query)
        {
            ArgumentNotNull(query, nameof(query));

            return _repository.Query(
                new FullName(new FirstName(query.FirstName!), new LastName(query.LastName!)),
                new DateRange(Date.FromString(query.InclusiveStartDate!), Date.FromString(query.InclusiveEndtDate!)),
                new Page(new PageIndex(query.RequestedPageIndex!.Value), new PageSize(query.RequestedPageSize!.Value)));
        }
    }
}
