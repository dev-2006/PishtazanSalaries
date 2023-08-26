using Microsoft.EntityFrameworkCore;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Persistence
{
    public class EmployeeRepositoryEfCore : IEmployeeRepository , IEmployeeQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepositoryEfCore(ApplicationDbContext dbContext) => 
            _dbContext = ArgumentNotNull(dbContext, nameof(dbContext));

        public Task Add(Employee employee) => Task.Run(() => _dbContext.Employees?.AddAsync(employee));

        public Task<Employee?> Load(FullName fullName) => 
            _dbContext.Employees?.SingleOrDefaultAsync(e => e.FullName.FirstName.Value == fullName.FirstName.Value &&
                                                      e.FullName.LastName.Value == fullName.LastName.Value);

        public Task SaveChanges() => _dbContext.SaveChangesAsync();

        public async Task<IncomeDetailDTO?> Query(FullName employeeFullName, Date date)
        {
            var i = await Load(employeeFullName);

            return i?.Incomes.Where(i => i.Date.GregorianDate == date.GregorianDate).
                    Select(convertToDto()).
                    SingleOrDefault();
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

        public async Task<IEnumerable<IncomeDetailDTO>?> Query(FullName employeeFullName, DateRange dateRange, Page page)
        {
            var i = await Load(employeeFullName);

            return i?.Incomes.Where(i => i.Date.GregorianDate >= dateRange.InclusiveStart.GregorianDate &&
                                         i.Date.GregorianDate <= dateRange.InclusiveEnd.GregorianDate).
                  OrderBy(i => i.Date.GregorianDate).
                  Skip(page.Index.Value * page.Size.Value).Take(page.Size.Value).
                  Select(convertToDto()).
                  AsEnumerable();

        }
    }
}
