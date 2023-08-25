using Pishtazan.Salaries.Infrastructure.Reflection;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;
namespace Pishtazan.Salaries.OvertimePolicies
{
    public class OvertimePolicyCalculatorFactory
    {
        public IOvertimePolicyCalculator[] OvertimePolicyCalculators { get; }

        public OvertimePolicyCalculatorFactory()
        {
            OvertimePolicyCalculators = AssemblyUtil.LoadInstances<IOvertimePolicyCalculator>();
        }

        public IOvertimePolicyCalculator Get(string calculatorName)
        {
            ArgumentNotNull(calculatorName, nameof(calculatorName));

            throw new NotImplementedException();
        }
    }
}
