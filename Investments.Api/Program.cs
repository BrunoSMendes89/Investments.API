using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Service.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection String
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//Connection
builder.Services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(mySqlConnection,
                ServerVersion.AutoDetect(mySqlConnection),
                b => b.MigrationsAssembly("Investments.Api").SchemaBehavior(MySqlSchemaBehavior.Ignore)));
// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<TestHandler>());

var app = builder.Build();

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
