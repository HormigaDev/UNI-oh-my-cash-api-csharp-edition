using App.Api.Filters;
using App.Application.Interfaces;
using App.Application.Validators;
using App.Infrastructure.Data;
using App.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpExceptionFilter>();
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddValidatorsFromAssemblyContaining<AccountCreateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AccountUpdateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryCreateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BudgetCreateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BudgetUpdateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TransactionCreateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TransactionUpdateValidator>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


// Registrar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Registrar serviços
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IBudgetsService, BudgetsService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Json(new
{
    name = "Oh My Cash API - C# Edition",
    version = "1.0.0",
    author = "Isai Medina <HormigaDev hormigadev7@gmail.com>"
}));

app.MapControllers();

app.Run();
