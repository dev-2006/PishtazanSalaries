using Pishtazan.Salaries.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Employees.Salaries
{
    public record Salary : ValueTypeBase<long>
    {
        public const long MIN = 1;

        public Salary(long value) : base(value)
        {
            if(value < MIN)
                throw new ArgumentOutOfRangeException(paramName: "salary", message: "salary amount is too few");
        }

        public Salary Add(Salary summed) => new Salary(Value + summed.Value);
    }
}
