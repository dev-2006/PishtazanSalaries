namespace Pishtazan.Salaries.OvertimePolicies.Calculators.Factory
{
    public interface IOvertimePolicyCalculatorFactory
    {
        IOvertimePolicyCalculator[] OvertimePolicyCalculators { get; }

        IOvertimePolicyCalculator Get(string calculatorName);
    }
}