using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.IncomeCalculationStrategies
{
    public class IncomeCalculationStrategy
    {
        public Income Calculate(SalaryDetail salaryDetail, IOvertimePolicyCalculator overtimeCalculator) => throw new NotImplementedException();
    }
}
