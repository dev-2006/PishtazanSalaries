using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees
{
    public class EmployeeRepositoryInMemory : IEmployeeRepository
    {
        public List<Employee> Employees = new List<Employee>();

        public Task Add(Employee employee)
        {
            return Task.Run(() => Employees.Add(employee));
        }

        public Task<Employee?> Load(FullName fullName)
        {
            return Task<Employee?>.Run(() => Employees.SingleOrDefault(e => e.FullName == fullName));
        }

        public Task SaveChanges()
        {
            return Task.CompletedTask;
        }
    }
}
