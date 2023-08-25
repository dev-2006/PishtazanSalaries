using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Employees.Salaries
{
    public record BasicSalary : Salary
    {
        public BasicSalary(long value) : base(value)
        {
        }
    }
}