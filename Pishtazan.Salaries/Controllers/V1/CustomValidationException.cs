using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace Pishtazan.Salaries.Controllers.V1
{
    [Serializable]
    internal class CustomValidationException : Exception
    {
        public ValidationProblemDetails ValidationProblemDetails { get; }

        public CustomValidationException(ValidationProblemDetails validationProblemDetails)
        {
            ValidationProblemDetails = validationProblemDetails;
        }
    }
}