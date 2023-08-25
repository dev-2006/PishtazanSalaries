using Pishtazan.Salaries.OvertimePolicies.Calculators;
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

        [Theory]
        [InlineData("CalculatorA", typeof(CalcurlatorA))]
        [InlineData("CalculatorB", typeof(CalcurlatorB))]
        [InlineData("CalculatorC", typeof(CalcurlatorC))]
        public void Get_ExistsCalculatorName_ReturnsCalculator(string overTimeCalculatorName, Type calculatorType)
        {
            IOvertimePolicyCalculator calculator = factory.Get(overTimeCalculatorName);

            Assert.NotNull(calculator);
            Assert.True(calculator.GetType() == calculatorType);
        }

        [Fact]
        public void Constructor_LoadsAllOvertimePolicyCalculators()
        {
            Assert.Equal(3, factory.OvertimePolicyCalculators?.Length);
        }
    }
}
