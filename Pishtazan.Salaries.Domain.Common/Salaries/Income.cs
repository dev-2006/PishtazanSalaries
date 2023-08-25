using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Common.Salaries
{
    public record Income : Salary
    {
        public Income(long value) : base(value)
        {
        }

        public Income(Salary salary) : base(ArgumentNotNull(salary, "salary").Value)
        {
        }
    }
}
