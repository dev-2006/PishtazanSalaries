using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees.Repository
{
    public class EmployeeRepositoryInMemoryTests
    {
        [Fact]
        public async void QueryExactDate_WhenEmployeeNotExist_ReturnsNull()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(NotEmployeeFullName(), Date.FromString("14020101"));

            Assert.Null(result);
        }

        private FullName NotEmployeeFullName()
        {
            return new FullName(new FirstName("hasan"), new LastName("hasani"));
        }

        [Fact]
        public async void QueryExactDate_WhenDateNotExist_ReturnsNull()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(), Date.FromString("14020102"));

            Assert.Null(result);
        }

        [Fact]
        public async void QueryExactDate_WhenDateExists_ReturnsIncomeDetailDTO()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(), Date.FromString("14020301"));

            Assert.NotNull(result);

            Assert.Equal(30, result.BasicSalary);
            Assert.Equal(31, result.Allowance);
            Assert.Equal(32, result.Transportation);
        }

        [Fact]
        public async void QueryRange_WhenEmployeeNotExist_ReturnsEmptyEnumarable()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(NotEmployeeFullName(), 
                new DateRange(Date.FromString("14020101"), Date.FromString("14020201")),
                new Page(new PageIndex(0), new PageSize(1)));

            Assert.Empty(result!);
        }

        [Fact]
        public async void QueryRange_WhenDateRangeNotExist_ReturnsEmptyEnumarable()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(),
                new DateRange(Date.FromString("14020601"), Date.FromString("14020701")),
                new Page(new PageIndex(0), new PageSize(1)));

            Assert.Empty(result!);
        }

        [Fact]
        public async void QueryRange_WhenDateRangeExistsAndFullDataRequested_ReturnsAllIncomes()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(),
                new DateRange(Date.FromString("14020101"), Date.FromString("14020601")),
                new Page(new PageIndex(0), new PageSize(20)));

            Assert.Equal(5, result!.Count());
        }

        [Fact]
        public async void QueryRange_WhenDateRangeExistsAndPageIsNotLimiting_ReturnsAllIncomes()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(),
                new DateRange(Date.FromString("14020201"), Date.FromString("14020401")),
                new Page(new PageIndex(0), new PageSize(10)));

            Assert.Equal(3, result!.Count());
        }

        [Fact]
        public async void QueryRange_WhenDateRangeExistsAndPageIsLimiting_ReturnsLimitedIncomes()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(),
                new DateRange(Date.FromString("14020101"), Date.FromString("14020601")),
                new Page(new PageIndex(0), new PageSize(2)));

            Assert.Equal(2, result!.Count());
        }

        [Fact]
        public async void QueryRange_WhenDateRangeExistsAndPageIsLimitingLastPage_ReturnsLastPageIncomes()
        {
            EmployeeRepositoryInMemory repository = getSeededRepository();

            var result = await repository.Query(EmployeeFullName(),
                new DateRange(Date.FromString("14020101"), Date.FromString("14020601")),
                new Page(new PageIndex(2), new PageSize(2)));

            Assert.Single(result!);
        }

        private EmployeeRepositoryInMemory getSeededRepository()
        {
            EmployeeRepositoryInMemory repositoryInMemory = new EmployeeRepositoryInMemory
            {
                Employees = new List<Employee>()
                {
                    new Employee(EmployeeFullName(), incomes: new List<IncomeDetail>()
                        {
                            new IncomeDetail(Date.FromString("14020101"), NewSalaryDetail(1), new Income(1)),
                            new IncomeDetail(Date.FromString("14020201"), NewSalaryDetail(2), new Income(2)),
                            new IncomeDetail(Date.FromString("14020301"), NewSalaryDetail(3), new Income(3)),
                            new IncomeDetail(Date.FromString("14020401"), NewSalaryDetail(4), new Income(4)),
                            new IncomeDetail(Date.FromString("14020501"), NewSalaryDetail(5), new Income(5))
                        })
                }
            };

            return repositoryInMemory;
        }

        private static FullName EmployeeFullName()
        {
            return new FullName(new FirstName("ali"), new LastName("ahmadi"));
        }

        private static SalaryDetail NewSalaryDetail(int seed)
        {
            return new SalaryDetail(new BasicSalary(seed * 10), new Allowance(seed * 10 + 1), new Transportation(seed * 10 + 2));
        }
    }
}
