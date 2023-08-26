using Pishtazan.Salaries.Domain.Resources;
using Pishtazan.Salaries.Framework;
using System.Runtime.Serialization;

namespace Pishtazan.Salaries.Domain.Employees.Exceptions
{
    [Serializable]
    public class SalaryInSameMonthNotFoundException : NotFoundDomainException
    {
        public SalaryInSameMonthNotFoundException() : base(ErrorMessageResource.SalaryInSameMonthNotFoundError)
        {
        }
    }
}