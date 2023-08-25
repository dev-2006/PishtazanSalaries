using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees
{
    public class FullNameTests
    {
        [Fact]
        public void Constructor_NullFirstName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FullName(firstName: null!, new LastName("ahmadi")));
        }

        [Fact]
        public void Constructor_NullLastName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FullName(new FirstName("ali"), lastName: null!));
        }

        [Fact]
        public void DifferentFullNameObjectsWithSameValuesAreEqual()
        {
            FullName f1 = new FullName(new FirstName("ali"), new LastName("ahmadi"));
            FullName f2 = new FullName(new FirstName("ali"), new LastName("ahmadi"));

            Assert.Equal(f1, f2);
            Assert.True(f1 == f2);
            Assert.False(ReferenceEquals(f1, f2));
        }
    }
}
