using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Contracts.Command
{
    public class UpdateEmployeeSalary : EmployeeSalary
    {
        public UpdateEmployeeSalary()
        {

        }

        public UpdateEmployeeSalary(EmployeeSalary source) : base(source)
        {
        }
    }
}
