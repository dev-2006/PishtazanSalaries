using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Exceptions
{
    public class EmployeeNotFoundException : DomainException
    {
        public EmployeeNotFoundException() : base(ErrorMessageResource.EmployeeNotFoundError)
        {
        }
    }
}
