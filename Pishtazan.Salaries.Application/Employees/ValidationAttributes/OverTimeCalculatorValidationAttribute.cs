using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class OverTimeCalculatorValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            //بررسی وجود یا عدم وجود باید از طریق اتربیوت مربوط به خود بررسی شود و این ولیدیشن این مسئله را بررسی نمی کند
            if (value == null)
                return true;

            throw new NotImplementedException();
        }
    }
}