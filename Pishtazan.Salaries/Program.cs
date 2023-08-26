using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pishtazan.Salaries.Application.Employees.ValidationAttributes;
using Pishtazan.Salaries.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAndConfigVersioning();
builder.Services.AddControllers().AddDataAnnotationsLocalization();
builder.Services.AddAndConfigLocalization();
builder.Services.AddAndConfigSwagger();
builder.Services.AddAndConfigOvertimePolicies();
builder.Services.AddAndConfigApplicationServices();
builder.AddAndConfigPersistence();

var app = builder.Build();

app.CreateAndMigrateDataBaseIfNotExists();

app.UseApiExceptionHandling();
app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
