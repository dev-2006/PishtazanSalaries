using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class OverTimeCalculatorValidationAttribute : ValidationAttribute
    {
        public static IOvertimePolicyCalculator[] OvertimePolicyCalculators { get; set; } = null!;

        public override bool IsValid(object? value)
        {
            //بررسی وجود یا عدم وجود باید از طریق اتربیوت مربوط به خود بررسی شود و این ولیدیشن این مسئله را بررسی نمی کند
            if (value == null)
                return true;

            string valueStr = (string)value;

            if (OvertimePolicyCalculators == null)
                throw new InvalidOperationException();

            return OvertimePolicyCalculators.Any(o => o.Name == valueStr);
        }
    }
}