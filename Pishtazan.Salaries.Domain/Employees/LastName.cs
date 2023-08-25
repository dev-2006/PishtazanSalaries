using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Employees
{
    public record LastName : Name
    {
        public LastName(string value) : base(value)
        {
        }
    }
}
