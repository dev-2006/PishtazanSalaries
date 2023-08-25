using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Infrastructure.Validation;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.IncomeCalculationStrategies
{
    public class IncomeCalculationStrategy : IIncomeCalculationStrategy
    {
        public Income Calculate(SalaryDetail salaryDetail, IOvertimePolicyCalculator overtimeCalculator)
        {
            Validate.ArgumentNotNull(salaryDetail, nameof(salaryDetail));
            Validate.ArgumentNotNull(overtimeCalculator, nameof(overtimeCalculator));

            return new Income(salaryDetail.BasicSalary + salaryDetail.Allowance + salaryDetail.Transportation +
                overtimeCalculator.Calculate(salaryDetail.BasicSalary, salaryDetail.Allowance));
        }
    }
}
