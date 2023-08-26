using Microsoft.EntityFrameworkCore;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Pishtazan.Salaries.Persistence.DapperQuery
{
    public class EmployeeQueryRepositoryDapper : IEmployeeQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeQueryRepositoryDapper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            IncomeDetailDTO.DateIsPersian = false;
        }

        public Task<IncomeDetailDTO?> Query(FullName employeeFullName, Date date)
        {     
            var connection = _dbContext.Database.GetDbConnection();

            string query =
                "SELECT [i].[Date], [i].[Income], [i].[Allowance], [i].[BasicSalary], [i].[Transportation] " +
                " FROM ( " +
                "    SELECT TOP(1) [e].[EmployeeId] " +
                "    FROM [Employees] AS [e] " +
                "    WHERE [e].[FirstName] = @FirstName AND [e].[LastName] = @LastName " +
                " ) AS [t] " +
                " LEFT JOIN [IncomeDetail] AS [i] ON [t].[EmployeeId] = [i].[EmployeeId] " +
                " where [i].[Date] = @Date " +
                " ORDER BY [i].[Date]";

            return connection.QuerySingleOrDefaultAsync<IncomeDetailDTO>(query, 
                new 
                { 
                    FirstName = employeeFullName.FirstName.Value,
                    LastName = employeeFullName.LastName.Value,
                    Date = date.GregorianDate,
                })!;
        }

        public async Task<IEnumerable<IncomeDetailDTO>?> Query(FullName employeeFullName, DateRange dateRange, Page page)
        {
            var connection = _dbContext.Database.GetDbConnection();

            string query =
                "SELECT [i].[Date], [i].[Income], [i].[Allowance], [i].[BasicSalary], [i].[Transportation] " +
                " FROM ( " +
                "    SELECT TOP(1) [e].[EmployeeId] " +
                "    FROM [Employees] AS [e] " +
                "    WHERE [e].[FirstName] = @FirstName AND [e].[LastName] = @LastName " +
                " ) AS [t] " +
                " LEFT JOIN [IncomeDetail] AS [i] ON [t].[EmployeeId] = [i].[EmployeeId] " +
                " where [i].[Date] >= @DateStart and [i].[Date] <= @DateEnd " +
                " ORDER BY [i].[Date]";

            var items = await connection.QueryAsync<IncomeDetailDTO>(query,
                new
                {
                    FirstName = employeeFullName.FirstName.Value,
                    LastName = employeeFullName.LastName.Value,
                    DateStart = dateRange.InclusiveStart.GregorianDate,
                    DateEnd = dateRange.InclusiveEnd.GregorianDate,
                });

            return items.Skip(page.Index.Value * page.Size.Value).Take(page.Size.Value);
        }
    }
}
