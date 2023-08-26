using Pishtazan.Salaries.Infrastructure.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.OvertimePolicies.Calculators.Factory;

namespace Pishtazan.Salaries.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigOvertimePolicies(this IServiceCollection services)
    {
        OvertimePolicyCalculatorFactory overtimePolicyCalculatorFactory = new OvertimePolicyCalculatorFactory();

        services.AddSingleton<IOvertimePolicyCalculatorFactory>(overtimePolicyCalculatorFactory);

        OverTimeCalculatorValidationAttribute.OvertimePolicyCalculators = overtimePolicyCalculatorFactory.OvertimePolicyCalculators;

        return services;
    }
    public static IServiceCollection AddAndConfigLocalization(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        var supportedCultures = new List<CultureInfo> { new("en"), new("fa") };
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("fa");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }

    public static IServiceCollection AddAndConfigSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerLanguageHeader>();  
        });

        return services;
    }
}