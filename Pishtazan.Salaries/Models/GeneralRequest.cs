using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Employees;
using System.ComponentModel.DataAnnotations;

namespace Pishtazan.Salaries.Models
{
    public class GeneralRequest
    {
        [Display(ResourceType = typeof(DisplayNameResource), Name = "Data")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(maximumLength: 2 * 1024, MinimumLength = 5,
            ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringLengthError")]
        public string? Data { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "OverTimeCalculator")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [OverTimeCalculatorValidation(ErrorMessageResourceType = typeof(ErrorMessageResource),
            ErrorMessageResourceName = "InvalidError")]
        public string? OverTimeCalculator { get; set; }
    }
}
