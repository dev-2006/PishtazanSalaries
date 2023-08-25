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

        [Theory]
        [InlineData("14010801", 1401, 8, 1)]
        [InlineData("13800129", 1380, 1, 29)]
        [InlineData(" 14010801 ", 1401, 8, 1)]
        [InlineData("  13800129  ", 1380, 1, 29)]
        public void FromString_ValidDateStr_CreatesDate(string dateStr, int year, int month, int day)
        {
            Date d = Date.FromString(dateStr);

            Assert.Equal(d.Year, year);
            Assert.Equal(d.Month, month);
            Assert.Equal(d.Day, day);
        }

        [Theory]
        [InlineData("14010831")]
        [InlineData("14010832")]
        [InlineData("14011301")]
        [InlineData("14010001")]
        [InlineData("14010100")]
        public void FromString_ValidDateStrButInvalidPersianDate_ThrowsArgumentOutOfRangeException(string dateStr)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Date.FromString(dateStr)); 
        }
    }
}
