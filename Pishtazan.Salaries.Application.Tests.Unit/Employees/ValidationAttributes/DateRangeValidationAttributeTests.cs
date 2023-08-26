using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Tests.Unit.Employees.ValidationAttributes
{
    public class DateRangeValidationAttributeTests
    {
        DateRangeValidationAttribute att = new DateRangeValidationAttribute();

        [Fact]
        public void IsValid_NullArgument_ReturnsTrueAsNullValidationMustBeCheckViaItsOwnValidations()
        {
            Assert.True(att.IsValid(null));
        }

        [Fact]
        public void IsValid_NotGetEmployeeSalariesInDateRangeObject_ReturnsTrue()
        {
            Assert.True(att.IsValid(new object()));
        }
    }
}
