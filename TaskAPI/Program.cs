using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // Return 406 Not Acceptable if the client does not accept JSON.
}).AddXmlDataContractSerializerFormatters(); //Added xml formatter to the API.
// Add services to the container.


// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskAPI",
        Version = "v1",
        Description = "A simple API for managing tasks and authors",
        Contact = new OpenApiContact
        {
            Name = "API Support",
            Email = "support@taskapi.com"
        }
    });
});

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Inject AutoMapper to the API.
builder.Services.AddScoped<ITodoRepository, TodoMySQLServerService>(); // Dependancy injection. Assign TodoService to ITodoRepository interface
builder.Services.AddScoped<IAuthorRepository, AuthorMySqlServerService>(); // Dependancy injection. Assign AuthorService to IAuthorRepository interface

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskAPI v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
    
    app.MapOpenApi();
}
else
{
    app.UseExceptionHandler(app =>
    {
        app.Run(async context =>
        {
            context.Response.StatusCode = 500; // Internal Server Error
            await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
        });
    });
}

app.MapControllers(); // Map controllers to the app pipeline
app.UseHttpsRedirection();
app.Run();