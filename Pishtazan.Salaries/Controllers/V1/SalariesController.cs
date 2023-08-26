using Microsoft.AspNetCore.Mvc;
using Pishtazan.Salaries.Application;
using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Application.Employees.Contracts.Query;
using System.Data.Common;

namespace Pishtazan.Salaries.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SalariesController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IEmployeeReadApplicationService _queryApi;
        private readonly ILogger<SalariesController> _logger;

        public SalariesController(IApplicationService applicationService, 
            IEmployeeReadApplicationService queryApi, ILogger<SalariesController> logger)
        {
            _applicationService = applicationService;
            _queryApi = queryApi;
            _logger = logger;
        }

        [HttpGet(Name = "GetSalary")]
        public Task<IActionResult> Get([FromQuery] GetEmployeeSalaryInExactDate request)
            => RequestHandler.HandleQuery(() => _queryApi.Query(request), _logger);

        [HttpGet("[action]", Name = "GetSalariesInRange")]
        public Task<IActionResult> GetRange([FromQuery] GetEmployeeSalariesInDateRange request)
            => RequestHandler.HandleQuery(() => _queryApi.Query(request), _logger);

        [HttpPost(Name = "CreateSalary")]
        public Task<IActionResult> CreateSalary(CreateEmployeeSalary request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _logger);

        [HttpPut(Name = "UpdateSalary")]
        public Task<IActionResult> UpdateSalary(UpdateEmployeeSalary request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _logger);

        [HttpDelete(Name = "DeleteSalary")]
        public Task<IActionResult> DeleteSalary(DeleteEmployeeSalary request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _logger);
    }
}