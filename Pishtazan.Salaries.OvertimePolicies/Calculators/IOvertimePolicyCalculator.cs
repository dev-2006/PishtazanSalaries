using Pishtazan.Salaries.Domain.Employees.Salaries;

namespace Pishtazan.Salaries.OvertimePolicies.Calculators
{
    public interface IOvertimePolicyCalculator
    {
        Salary Calculate(BasicSalary basicSalary, Allowance allowance);

        string Name { get; }
    }
}