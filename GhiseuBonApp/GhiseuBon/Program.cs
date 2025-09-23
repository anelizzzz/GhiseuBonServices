using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.UnitOfWork;
using FluentMigrator.Runner;
using FluentValidation;
using FluentValidation.AspNetCore;
using GhiseuBon.Mapping;
using GhiseuBon.Validators;
using GhiseuBonMigrations.Migrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddSingleton<ISqlAccess, SqlAccess>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BonValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GhiseuValidator>();


builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer() // or .AddPostgres(), .AddMySql(), etc.
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
        .ScanIn(Assembly.GetAssembly(typeof(CreateBonTable))).For.Migrations()) // or specify your migration assembly
    .AddLogging(lb => lb.AddFluentMigratorConsole());


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
