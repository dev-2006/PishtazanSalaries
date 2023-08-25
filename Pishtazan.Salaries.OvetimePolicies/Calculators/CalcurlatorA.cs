using Pishtazan.Salaries.Domain.Employees.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.OvetimePolicies.Calculators
{
    public class CalcurlatorA
    {
        public Salary Calculate(BasicSalary basicSalary, Allowance allowance)
        {
            ArgumentNullException.ThrowIfNull(basicSalary, nameof(basicSalary));
            ArgumentNullException.ThrowIfNull(allowance, nameof(allowance));

            return basicSalary + allowance;
        }
    }
}
