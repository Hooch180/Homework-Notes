using Homework.Application;
using Homework.Infrastructure;
using Notes.Api;

// Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure();

// App
var app = builder.Build();
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
