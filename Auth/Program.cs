using Auth.Context;
using Auth.Interfaces;
using Auth.Model;
using Auth.Services;
using Auth.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();   

// Add services to the container.

builder.Services.AddDbContext<PostgresContext>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddKeyedScoped<ICommonServices<User>, UserService>("UserService");
builder.Services.AddScoped<IPaginationUtil, PaginationUtil>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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