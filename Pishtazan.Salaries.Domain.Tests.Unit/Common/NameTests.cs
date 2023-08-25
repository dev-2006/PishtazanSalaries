using Pishtazan.Salaries.Domain.Common;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Common
{
    public class NameTests
    {
        [Fact]
        public void Constructor_NullArgument_ThrowsArgumentNullException()
        {
            var e = Record.Exception(() => new Name(null!));

            Assert.IsType<ArgumentNullException>(e);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("a")]
        [InlineData("b")]
        [InlineData(" a")]
        [InlineData("a  ")]
        public void Constructor_TooSmallNames_ThrowsArgumentOutOfRangeException(string nameStr)
        {
            var e = Record.Exception(() => new Name(nameStr));

            Assert.IsType<ArgumentOutOfRangeException>(e);
        }

        [Theory]
        [InlineData(201)]
        [InlineData(300)]
        public void Constructor_TooBigNames_ThrowsArgumentOutOfRangeException(int nameLength)
        {
            var e = Record.Exception(() => new Name(new string('a', nameLength)));

            Assert.IsType<ArgumentOutOfRangeException>(e);
        }

        [Theory]
        [InlineData("ali", "ali")]
        [InlineData("ali ", "ali")]
        [InlineData(" ali", "ali")]
        [InlineData("  ali  ", "ali")]
        [InlineData("  ali reza  ", "ali reza")]
        public void Constructor_ValidNames_CreatesNameWithTrimedStringInValueProperty(string nameStr, string expectedValue)
        {
            var name = new Name(nameStr);

            Assert.Equal(expectedValue, name.Value);
        }

        [Fact]
        public void DiffrentNameObjectWithSameValueAreEqual()
        {
            var name1 = new Name("ali");
            var name2 = new Name("  ali  ");

            Assert.Equal(name1, name2);
            Assert.True(name1 == name2);
            Assert.False(ReferenceEquals(name1, name2));
        }
    }
}
