using Pishtazan.Salaries.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Pishtazan.Salaries.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}