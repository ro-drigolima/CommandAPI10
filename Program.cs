using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = new NpgsqlConnectionStringBuilder
{
  ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"),
  Username = builder.Configuration["DbUserId"],
  Password = builder.Configuration["DbPassword"]  
};

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString.ConnectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
