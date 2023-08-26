using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    public class EmployeeRepositoryInMemory : IEmployeeRepository, IEmployeeQueryRepository
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
        public Task<IncomeDetailDTO?> Query(FullName employeeFullName, Date date)
        {
            return Task<IncomeDetailDTO?>.Run(() =>
                Employees.Where(e => e.FullName == employeeFullName).
                    SelectMany(e => e.Incomes).
                    Where(i => i.Date.GregorianDate == date.GregorianDate).
                    Select(convertToDto()).
                    SingleOrDefault());
        }

        private static Func<IncomeDetail, IncomeDetailDTO> convertToDto()
        {
            return i => new IncomeDetailDTO()
            {
                Date = i.Date.GregorianDate.ToString(),
                BasicSalary = i.SalaryDetails.BasicSalary.Value,
                Allowance = i.SalaryDetails.Allowance.Value,
                Transportation = i.SalaryDetails.Transportation.Value,
                Income = i.Income.Value,
            };
        }

        public Task<IEnumerable<IncomeDetailDTO>?> Query(FullName employeeFullName, DateRange dateRange, Page page)
        {
            return Task<IEnumerable<IncomeDetailDTO>?>.Run(() =>
                Employees.Where(e => e.FullName == employeeFullName).
                    SelectMany(e => e.Incomes).
                    Where(i => i.Date.GregorianDate >= dateRange.InclusiveStart.GregorianDate &&
                               i.Date.GregorianDate <= dateRange.InclusiveEnd.GregorianDate).
                    OrderBy(i => i.Date.GregorianDate).
                    Skip(page.Index.Value * page.Size.Value).Take(page.Size.Value).
                    Select(convertToDto())?.AsEnumerable());
        }

    }
}
