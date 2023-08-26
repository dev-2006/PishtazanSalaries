using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    internal interface IEmployeeReadRepository
    {
        Task<Employee?> Query(FullName employeeFullName, Date date);
        Task<IEnumerable<Employee>?> Query(FullName employeeFullName, DateRange dateRange, Page page);
    }
}
