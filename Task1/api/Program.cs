using api.CQRS;
using api.CQRS.Commands;
using api.CQRS.Queries;
using api.Data;
using api.Models;
using api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();

// Register database connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new OracleConnection(builder.Configuration.GetConnectionString("OracleConnection")));

// Register repositories
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Register CQRS handlers
builder.Services.AddScoped<IQueryHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>, GetAllTransactionsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetTransactionByIdQuery, Transaction?>, GetTransactionByIdQueryHandler>();
builder.Services.AddScoped<ICommandHandler<AddTransactionCommand, string>, AddTransactionCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateTransactionCommand, bool>, UpdateTransactionCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteTransactionCommand, bool>, DeleteTransactionCommandHandler>();

var app = builder.Build();

// app.UseHttpsRedirection();

// Global exception handling
app.UseExceptionHandler(appError =>
{
  appError.Run(async context =>
  {
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = "application/json";

    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
    if (contextFeature != null)
    {
      await context.Response.WriteAsync(JsonSerializer.Serialize(new
      {
        StatusCode = context.Response.StatusCode,
        Message = "Internal Server Error.",
        DetailedMessage = app.Environment.IsDevelopment() ? contextFeature.Error.Message : null
      }));
    }
  });
});

app.UseAuthorization();

app.MapControllers();

app.Run();
