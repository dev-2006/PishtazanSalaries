using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee?> Load(FullName fullName);

        Task Add(Employee employee);

        Task SaveChanges();
    }
}
