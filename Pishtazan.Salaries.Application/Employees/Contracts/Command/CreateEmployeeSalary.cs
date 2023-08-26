using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Contracts.Command
{
    public class CreateEmployeeSalary : EmployeeSalary
    {
        public CreateEmployeeSalary()
        {

        }

        public CreateEmployeeSalary(EmployeeSalary source) : base(source)
        {
        }
    }
}
