using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees
{
    public class DateTests
    {
        [Fact]
        public void FromString_NullArgument_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Date.FromString(null!));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("a")]
        [InlineData("  ab  ")]
        [InlineData("1400")]
        [InlineData("140001")]
        [InlineData("1400010")]
        [InlineData("1400010 ")]
        [InlineData(" 1400010 ")]
        [InlineData(" 1400010a")]
        [InlineData("1400010a")]
        [InlineData("a14000101")]
        public void FromString_IncompleteAndInvalidDateStr_ThrowsArgumentOutOfRangeException(string dateStr)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Date.FromString(dateStr));
        }
    }
}
