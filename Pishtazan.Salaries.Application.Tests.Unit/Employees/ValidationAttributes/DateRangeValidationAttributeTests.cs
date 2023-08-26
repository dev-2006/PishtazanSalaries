using Pishtazan.Salaries.Application.Employees.Contracts.Query;
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

        [Fact]
        public void IsValid_GetEmployeeSalariesInDateRangeObjectWithNullStartDate_ReturnsTrue()
        {
            Assert.True(att.IsValid(new GetEmployeeSalariesInDateRange() { InclusiveStartDate = null}));
        }

        [Fact]
        public void IsValid_GetEmployeeSalariesInDateRangeObjectWithNullEndDate_ReturnsTrue()
        {
            Assert.True(att.IsValid(new GetEmployeeSalariesInDateRange() { InclusiveEndtDate = null }));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(" as ")]
        [InlineData("1402")]
        [InlineData("140201")]
        [InlineData("1402010")]
        [InlineData("1402010a")]
        public void IsValid_GetEmployeeSalariesInDateRangeObjectWithIncorectStartDate_ReturnsTrue(string dateStr)
        {
            Assert.True(att.IsValid(new GetEmployeeSalariesInDateRange() { InclusiveStartDate = dateStr }));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(" as ")]
        [InlineData("1402")]
        [InlineData("140201")]
        [InlineData("1402010")]
        [InlineData("1402010a")]
        public void IsValid_GetEmployeeSalariesInDateRangeObjectWithIncorectEndDate_ReturnsTrue(string dateStr)
        {
            Assert.True(att.IsValid(new GetEmployeeSalariesInDateRange() { InclusiveEndtDate = dateStr }));
        }
    }
}
