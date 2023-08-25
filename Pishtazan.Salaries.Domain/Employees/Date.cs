using Pishtazan.Salaries.Domain.Common;
using Pishtazan.Salaries.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Employees
{
    public record Date
    {
        public static Date FromString(string value)
        {
            Validate.ArgumentNotNull(value, "value");

            throw new NotImplementedException();
        }
    }
}
