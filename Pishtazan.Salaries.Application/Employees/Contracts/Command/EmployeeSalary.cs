using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Contracts.Command
{
    public class EmployeeSalary
    {
        [Display(ResourceType = typeof(DisplayNameResource), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(maximumLength: Name.MAX_LENGTH, MinimumLength = Name.MIN_LENGTH,
            ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringLengthError")]
        public string? FirstName { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "LastName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(maximumLength: Name.MAX_LENGTH, MinimumLength = Name.MIN_LENGTH,
            ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringLengthError")]
        public string? LastName { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Date")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [DateValidation(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "FormatError")]
        public string? Date { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "BasicSalary")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(maximum: Salary.MAX, minimum: Salary.MIN,
             ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RangeError")]
        public long? BasicSalary { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Allowance")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(maximum: Salary.MAX, minimum: Salary.MIN,
             ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RangeError")]
        public long? Allowance { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Transportation")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(maximum: Salary.MAX, minimum: Salary.MIN,
             ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RangeError")]
        public long? Transportation { get; set; }

        public EmployeeSalary()
        {
        }

        protected EmployeeSalary(EmployeeSalary source)
        {
            copyFrom(source);
        }

        private void copyFrom(EmployeeSalary other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Date = other.Date;
            BasicSalary = other.BasicSalary;
            Allowance = other.Allowance;
            Transportation = other.Transportation;
        }
    }
}
