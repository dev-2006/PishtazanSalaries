using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Application.Resources;
using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Application.Employees.Contracts.Query
{
    [DateRangeValidation]
    public class GetEmployeeSalariesInDateRange
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

        [Display(ResourceType = typeof(DisplayNameResource), Name = "StartDate")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [DateValidation(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "FormatError")]
        public string? InclusiveStartDate { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "EndDate")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [DateValidation(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "FormatError")]
        public string? InclusiveEndtDate { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "PageIndex")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(maximum: PageIndex.MAX, minimum: PageIndex.MIN,
             ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RangeError")]
        public int? RequestedPageIndex { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "PageSize")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(maximum: PageSize.MAX, minimum: PageSize.MIN,
             ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RangeError")]
        public int? RequestedPageSize { get; set; }
    }
}
