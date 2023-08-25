using Pishtazan.Salaries.Domain.Common;
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
    }
}
