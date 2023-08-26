using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Application.Employees.ValidationAttributes
{
    public class DateRangeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            //بررسی نال بودن و الزامی بودن باید از طریق اتریبیوت های مربوط به خود بررسی شود و این
            //کلاس برای اینکه پیام های خطایش با آنها ترکیب نشود در این حالت ها ترو بر می گرداند
            if (value == null)
                return true;

            if (value is not GetEmployeeSalariesInDateRange)
                return true;

            GetEmployeeSalariesInDateRange query = (GetEmployeeSalariesInDateRange)value;

            Date start, end;
            try
            {
                start = Date.FromString(query.InclusiveStartDate!);
                end = Date.FromString(query.InclusiveEndtDate!);
            }
            catch
            {
                return true;//این اتریبیوت بر روی کل کلاس عمل می کند و تنها زمانیکه مقادیر خام درست باشند بررسی می کند
                            //تا پیام هایش با سایر اتریبیوت ها ترکیب نشود
            }

            if (start.GregorianDate > end.GregorianDate)
                return false;

            return true;
        }
    }
}