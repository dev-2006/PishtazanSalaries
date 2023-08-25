using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class OverTimeCalculatorValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            throw new NotImplementedException();
        }
    }
}