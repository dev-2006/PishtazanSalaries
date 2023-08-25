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
    }
}
