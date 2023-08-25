using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.OvertimePolicies.Calculators;

namespace Pishtazan.Salaries.Domain.IncomeCalculationStrategies
{
    public interface IIncomeCalculationStrategy
    {
        Income Calculate(SalaryDetail salaryDetail, IOvertimePolicyCalculator overtimeCalculator);
    }
}