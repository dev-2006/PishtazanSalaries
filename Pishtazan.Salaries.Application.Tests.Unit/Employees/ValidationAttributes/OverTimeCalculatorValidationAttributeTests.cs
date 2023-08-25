using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees.ValidationAttributes
{
    public class OverTimeCalculatorValidationAttributeTests
    {
        OverTimeCalculatorValidationAttribute validationAttribute = new OverTimeCalculatorValidationAttribute();

        [Fact]
        public void IsValid_NullArgument_ReturnsTrueForPreventingDuplicateErrorMessageWithRequiredAttribute()
        {
            Assert.True(validationAttribute.IsValid(null!));
        }

        [Fact]
        public void IsValid_WhenListOfOverTimeCalculatorsNotSet_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => validationAttribute.IsValid(""));
        }
    }
}
