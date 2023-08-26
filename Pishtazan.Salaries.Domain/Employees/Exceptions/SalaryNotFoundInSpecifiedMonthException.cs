using Pishtazan.Salaries.Domain.Resources;
using Pishtazan.Salaries.Framework;
using System.Runtime.Serialization;

namespace Pishtazan.Salaries.Domain.Employees.Exceptions
{
    [Serializable]
    public class SalaryNotFoundInSpecifiedDateException : NotFoundDomainException
    {
        public SalaryNotFoundInSpecifiedDateException() : base(ErrorMessageResource.SalaryNotFoundInSpecifiedDateError)
        {
        }
    }
}