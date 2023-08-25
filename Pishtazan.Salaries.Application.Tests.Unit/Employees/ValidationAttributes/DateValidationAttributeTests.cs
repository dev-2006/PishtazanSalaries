using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees.ValidationAttributes
{
    public class DateValidationAttributeTests
    {
        DateValidationAttribute validationAttribute = new DateValidationAttribute();

        [Fact]
        public void IsValid_NullArgument_ReturnsTrueForPreventingDuplicateErrorMessageWithRequiredAttribute()
        {
            Assert.True(validationAttribute.IsValid(null!));
        }

        [Theory]
        [InlineData("14010305")]
        [InlineData("13901226")]
        public void IsValid_ValidDateStr_ReturnsTrue(string dateStr)
        {
            Assert.True(validationAttribute.IsValid(dateStr));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("  ba ")]
        [InlineData("1390")]
        [InlineData("139003")]
        [InlineData("1390030")]
        [InlineData("1390030a")]
        public void IsValid_InvalidDateStr_ReturnsFalse(string dateStr)
        {
            Assert.False(validationAttribute.IsValid(dateStr));
        }
    }
}
