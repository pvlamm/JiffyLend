using JiffyLend.Core.Infrastructure;
using JiffyLend.Core.Infrastructure.Extensions;
using JiffyLend.Module.Card.Application;
using JiffyLend.Module.Card.Infrastructure;
using JiffyLend.Module.Core.Application;
using JiffyLend.Module.Core.Infrastructure;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication();

builder.Services.AddOpenApi();

builder.Services.AddCoreInfrastructure(builder.Configuration);

builder.Services.AddModuleCoreApplication();
builder.Services.AddModuleCoreInfrastructure(builder.Configuration);

builder.Services.AddModuleCardApplication();
builder.Services.AddModuleCardInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("JiffyLend WebAPI")
            .WithTheme(ScalarTheme.Kepler)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapEndpoints();

app.Run();

// This exists for Testing
public partial class Program;