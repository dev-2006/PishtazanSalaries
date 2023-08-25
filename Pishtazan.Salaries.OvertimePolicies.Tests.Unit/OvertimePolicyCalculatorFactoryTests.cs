using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.OvertimePolicies.Tests.Unit
{
    public class OvertimePolicyCalculatorFactoryTests
    {
        OvertimePolicyCalculatorFactory factory = new OvertimePolicyCalculatorFactory();

        [Fact]
        public void Get_NullCalculatorName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => factory.Get(null!));
        }
    }
}
