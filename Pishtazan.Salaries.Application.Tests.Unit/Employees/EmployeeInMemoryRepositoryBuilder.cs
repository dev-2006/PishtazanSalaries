using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees
{
    internal class EmployeeRepositoryBuilder
    {
        internal static readonly string EXIST_EMP_FN = "ali";
        internal static readonly string EXIST_EMP_LN = "ahmadi";
        internal static readonly FullName EXIST_EMP_FULL_NAME = new FullName(new FirstName(EXIST_EMP_FN), 
            new LastName(EXIST_EMP_LN));

        internal static readonly string NOT_EXIST_EMP_FN = "hasan";
        internal static readonly string NOT_EXIST_EMP_LN = "hasani";

        internal static readonly string EXIST_SALARY_DATE_STR = "14020305";
        internal static readonly Date EXIST_SALARY_DATE = Date.FromString(EXIST_SALARY_DATE_STR);

        internal static readonly string NOT_EXIST_SALARY_DATE_SAME_MONTH_STR = "14020326";
        internal static readonly Date NOT_EXIST_SALARY_DATE_SAME_MONTH = Date.FromString(NOT_EXIST_SALARY_DATE_SAME_MONTH_STR);

        internal static readonly string NOT_EXIST_SALARY_DATE_DIFFERENT_MONTH_STR = "14020412";
        internal static readonly Date NOT_EXIST_SALARY_DATE_DIFFERENT_MONTH = Date.FromString(NOT_EXIST_SALARY_DATE_DIFFERENT_MONTH_STR);

        internal static readonly SalaryDetail EXIST_SALARY_DETAIL = new SalaryDetail(
            new BasicSalary(1), new Allowance(2), new Transportation(3));

        internal static readonly Income EXIST_INCOME = new Income(1 + 2 + 3 + (1 + 2));

        internal static readonly IncomeDetail EXIST_INCOME_DETAIL = new IncomeDetail(EXIST_SALARY_DATE, EXIST_SALARY_DETAIL,
            EXIST_INCOME);

        internal static EmployeeRepositoryInMemory CreateRepositoryWithOneEmployeeAndOneSalary() 
        {
            EmployeeRepositoryInMemory repository = new EmployeeRepositoryInMemory();

            repository.Employees.Add(new Employee(EXIST_EMP_FULL_NAME,
                    incomes: new List<IncomeDetail>() { EXIST_INCOME_DETAIL }));

            return repository;
        }
    }
}
