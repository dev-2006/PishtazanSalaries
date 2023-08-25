using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Contracts.Command
{
    public class DeleteEmployeeSalary
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
    }
}
