using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;

namespace Pishtazan.Salaries.Application.Employees
{
    public interface IEmployeeQueryApplicationService
    {
        Task<IncomeDetailDTO?> Query(GetEmployeeSalaryInExactDate query);
        Task<IEnumerable<IncomeDetailDTO>?> Query(GetEmployeeSalariesInDateRange query);
    }
}