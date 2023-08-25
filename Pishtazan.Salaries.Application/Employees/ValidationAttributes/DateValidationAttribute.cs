using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            //اعتبار سنجی مربوط به الزامی بودن و نال نبودن باید بصورت جداگانه و با اتربیوت مربوط به خود بررسی 
            //شود و در این اتریبوت تنها درست بودن بررسی می شود
            if (value == null)
                return true;

            try
            {
                string? dateStr = value as string;

                if (dateStr == null)
                    return false;

                Date.FromString(dateStr);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}