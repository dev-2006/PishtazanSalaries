using Pishtazan.Salaries.Domain.Common.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common.Tests.Unit.Salaries
{
    public class SalaryDetailTests
    {
        [Fact]
        public void Constructor_NullBasicSalary_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SalaryDetail(null!, new Allowance(1L), new Transportation(1L)));
        }

        [Fact]
        public void Constructor_NullAllowance_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SalaryDetail(new BasicSalary(1L), null!, new Transportation(1L)));
        }

        [Fact]
        public void Constructor_NullTransportation_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SalaryDetail(new BasicSalary(1L), new Allowance(1L), null!));
        }
    }
}
