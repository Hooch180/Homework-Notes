using Notes.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
}

var app = builder.Build();
{
    app.UseExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.MapControllers();

    app.Run();
}