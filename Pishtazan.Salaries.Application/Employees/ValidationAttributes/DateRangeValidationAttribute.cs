using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class DateRangeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            throw new NotImplementedException();
        }
    }
}