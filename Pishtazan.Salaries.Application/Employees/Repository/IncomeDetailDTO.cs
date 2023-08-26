using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.AccessControl;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    public class IncomeDetailDTO
    {
        string? _date = null;
        public string? Date 
        {
            get => _date; 
            set
            {
                if (DateIsPersian)
                    _date = value;
                else
                {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = DateTime.ParseExact(value!, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    _date = pc.GetYear(dt) + "/" + pc.GetMonth(dt) + "/" + pc.GetDayOfMonth(dt);
                }
            }
        }
        public long? BasicSalary { get; set; }
        public long? Allowance { get; set; }
        public long? Transportation { get; set; }
        public long? Income { get; set; }


        public static bool DateIsPersian = true;
    }
}