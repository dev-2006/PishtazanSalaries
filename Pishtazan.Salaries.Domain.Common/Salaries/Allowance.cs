using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common.Salaries
{
    public record Allowance : Salary
    {
        public Allowance(long value) : base(value)
        {
        }
    }
}
