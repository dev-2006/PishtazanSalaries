﻿using Pishtazan.Salaries.Infrastructure.Swagger;
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
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pishtazan.Salaries.Application.Employees.Repository;
using Pishtazan.Salaries.Application.Employees;
using Pishtazan.Salaries.Application;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;

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

    public static IServiceCollection AddAndConfigApplicationServices(this IServiceCollection services)
    {
        EmployeeRepositoryInMemory repository = new EmployeeRepositoryInMemory();
        services.AddSingleton<IEmployeeRepository>(repository);
        services.AddSingleton<IEmployeeReadRepository>(repository);

        services.AddSingleton<IIncomeCalculationStrategy, IncomeCalculationStrategy>();
        services.AddScoped<IApplicationService, EmployeeApplicationService>();
        services.AddScoped<IEmployeeQueryApplicationService, EmployeeQueryApplicationService>();

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

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static IServiceCollection AddAndConfigVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options => {
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });
        services.AddVersionedApiExplorer(options => {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddEndpointsApiExplorer();

        return services;
    }
}