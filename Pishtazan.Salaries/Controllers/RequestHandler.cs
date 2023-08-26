using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pishtazan.Salaries.Application.Employees.Repository;

namespace Pishtazan.Salaries.Controllers
{
    public static class RequestHandler
    {
        public static async Task<IActionResult> HandleCommand<T>(
            T request, Func<T, Task> handler, ILogger log)
        {
            log.LogDebug("Handling HTTP request of type {type}", typeof(T).Name);
            await handler(request);
            return new OkResult();
        }

        public static async Task<IActionResult> HandleQuery<TModel>(
            Func<Task<TModel>> query, ILogger log)
        {
            var result = await query();

            if(result == null) 
                return new NotFoundResult();

            if(result is IEnumerable<IncomeDetailDTO>)
            {
                if((result as IEnumerable<IncomeDetailDTO>)!.Count() == 0)
                    return new NotFoundResult();
            }


            return new OkObjectResult(result);
        }
    }
}