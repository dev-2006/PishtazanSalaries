using Pishtazan.Salaries.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Infrastructure.Tests.Unit.Reflection
{
    public class AssemblyUtilTests
    {
        [Fact]
        public void LoadInstances_CreatesAllInstancesOfSpecifiedTypeOrInterfaceInAssemblyThatSpecifiedTypeExists() 
        {
            ITestInterface[] instances = AssemblyUtil.LoadInstances<ITestInterface>();

            Assert.Equal(1, instances?.Length);
            Assert.IsType<TestInterfaceImpl>(instances?[0]);
        }
    }
}
