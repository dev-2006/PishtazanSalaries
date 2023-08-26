using Pishtazan.Salaries.Infrastructure.Reflection;
using Pishtazan.Salaries.OvertimePolicies.Calculators.Factory;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.InputProviders.Factory
{
    public class InputDataProviderFactory : IInputDataProviderFactory
    {
        public IInputProvider[] InputProviders { get; }

        public InputDataProviderFactory()
        {
            InputProviders = AssemblyUtil.LoadInstances<IInputProvider>();
        }

        public IInputProvider Get(string providerName)
        {
            ArgumentNotNull(providerName, nameof(providerName));

            return InputProviders.Single(o => o.Name == providerName);
        }
    }
}
