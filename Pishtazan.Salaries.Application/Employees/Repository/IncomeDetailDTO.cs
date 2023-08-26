using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    public class IncomeDetailDTO
    {
        public string? Date { get; set; }
        public long? BasicSalary { get; set; }
        public long? Allowance { get; set; }
        public long? Transportation { get; set; }
        public long? Income { get; set; }
    }
}