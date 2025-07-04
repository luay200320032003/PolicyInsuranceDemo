using FluentValidation;
using InsurancePolicy.Service;
using InsurancePolicy.Domain;
using InsurancePolicyAPI.Endpoints;
using InsurancePolicyAPI.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using InsurancePolicy.Data;
;

var builder = WebApplication.CreateBuilder(args);

// Register services for PolicyService and PolicyRepository
builder.Services.AddScoped<PolicyService>();
builder.Services.AddScoped<PolicyRepository>();

// Register FluentValidation for PolicyValidator
builder.Services.AddValidatorsFromAssemblyContaining<PolicyValidator>(); // This line now works with the added using directive

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InsurancePolicyDetailsAPI", Version = "v1" });
});

var app = builder.Build();

// Enable Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add global error handling for uncaught exceptions (optional)
app.UseExceptionHandler(app =>
{
    app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var problemDetails = new ProblemDetails
        {
            Status = 500,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred."
        };

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});
// Map custom endpoints from InsurancePolicyEndpoint
app.MapEndPoint();

// HTTPS redirection (if required)
app.UseHttpsRedirection();

// Run the app
app.Run();
