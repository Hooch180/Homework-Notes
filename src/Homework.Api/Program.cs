using HealthChecks.UI.Client;
using Homework.Application;
using Homework.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Notes.Api;
using Notes.Api.Middleware;
using Serilog;

// Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// App
var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseRequestContextLogging();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseRouting();
app.MapControllers();

app.Run();
