using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pishtazan.Salaries.Application;
using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using Pishtazan.Salaries.InputProviders.Factory;
using Pishtazan.Salaries.Models;
using System.Data.Common;

namespace Pishtazan.Salaries.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class SalariesController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IEmployeeQueryApplicationService _queryApi;
        private readonly IInputDataProviderFactory _inputDataProviderFactory;
        private readonly ILogger<SalariesController> _logger;

        public SalariesController(IApplicationService applicationService, IEmployeeQueryApplicationService queryApi,
            IInputDataProviderFactory inputDataProviderFactory, ILogger<SalariesController> logger)
        {
            _applicationService = applicationService;
            _queryApi = queryApi;
            _inputDataProviderFactory = inputDataProviderFactory;
            _logger = logger;
        }

        [HttpGet("[controller]", Name = "GetSalary")]
        public Task<IActionResult> Get([FromQuery] GetEmployeeSalaryInExactDate request)
            => RequestHandler.HandleQuery(() => _queryApi.Query(request), _logger);

        [HttpGet("[controller]/[action]", Name = "GetSalariesInRange")]
        public Task<IActionResult> GetRange([FromQuery] GetEmployeeSalariesInDateRange request)
            => RequestHandler.HandleQuery(() => _queryApi.Query(request), _logger);

        [HttpPost("{datatype}/[controller]", Name = "CreateSalary")]
        public Task<IActionResult> CreateSalary(string datatype, GeneralRequest request)
        {
            CreateEmployeeSalary cmd = new CreateEmployeeSalary(validateAndCreateEmployeeSalary(datatype, request));

            if (!ModelState.IsValid)
                throw new CustomValidationException(errorResult());

            return RequestHandler.HandleCommand(cmd, _applicationService.Handle, _logger);
        }

        private EmployeeSalary validateAndCreateEmployeeSalary(string datatype, GeneralRequest request)
        {
            EmployeeSalary employeeSalary = _inputDataProviderFactory.Get(datatype).Convert(request.Data!);
            employeeSalary.OverTimeCalculator = request.OverTimeCalculator;

            ModelState.ClearValidationState(nameof(employeeSalary));

            TryValidateModel(employeeSalary);

            return employeeSalary;
        }

        [HttpPut("{datatype}/[controller]", Name = "UpdateSalary")]
        public Task<IActionResult> UpdateSalary(string datatype, GeneralRequest request)
        {
            UpdateEmployeeSalary cmd = new UpdateEmployeeSalary(validateAndCreateEmployeeSalary(datatype, request));

            if (!ModelState.IsValid)
                throw new CustomValidationException(errorResult());

            return RequestHandler.HandleCommand(cmd, _applicationService.Handle, _logger);
        }

        private ValidationProblemDetails errorResult()
        {
            var details = new ValidationProblemDetails(ModelState);
            details.Extensions["traceId"] = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            details.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
            details.Status = StatusCodes.Status400BadRequest;

            return details;
        }

        [HttpDelete(Name = "DeleteSalary")]
        public Task<IActionResult> DeleteSalary(DeleteEmployeeSalary request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _logger);
    }
}