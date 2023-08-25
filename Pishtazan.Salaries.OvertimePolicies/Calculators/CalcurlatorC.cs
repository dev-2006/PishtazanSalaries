using Pishtazan.Salaries.Domain.Employees.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.OvertimePolicies.Calculators
{
    public class CalcurlatorC : IOvertimePolicyCalculator 
    {
        public const string NAME = "CalculatorC";
        public string Name => NAME;

        public Salary Calculate(BasicSalary basicSalary, Allowance allowance)
        {
            ArgumentNotNull(basicSalary, nameof(basicSalary));
            ArgumentNotNull(allowance, nameof(allowance));

            return basicSalary + allowance + allowance + allowance;
        }
    }
}
