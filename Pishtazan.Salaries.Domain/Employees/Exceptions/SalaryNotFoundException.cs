using Pishtazan.Salaries.Domain.Resources;
using Pishtazan.Salaries.Framework;
using System.Runtime.Serialization;

namespace Pishtazan.Salaries.Domain.Employees.Exceptions
{
    [Serializable]
    public class SalaryNotFoundException : DomainException
    {
        public SalaryNotFoundException() : base(ErrorMessageResource.SalaryNotFoundError)
        {
        }
    }
}