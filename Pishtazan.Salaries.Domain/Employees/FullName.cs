using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Employees
{
    public class FullName
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        public FullName(FirstName firstName, LastName lastName)
        {
            FirstName = ArgumentNotNull(firstName, nameof(firstName));
            LastName = ArgumentNotNull(lastName, nameof(lastName));
        }
    }
}
