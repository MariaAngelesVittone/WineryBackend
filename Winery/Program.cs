using Microsoft.EntityFrameworkCore;
using Data;
using Common.Services;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Servicios
builder.Services.AddScoped<IWineService, WineService>();
builder.Services.AddScoped<IUserService, UserService>();

// Repositorios
builder.Services.AddScoped<IWineRepository, WineRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<WineryContext>(dbContextOptions => dbContextOptions.
UseSqlite(builder.Configuration["ConnectionStrings:WineryAPIDBConnectionString"]));

builder.Services.AddControllers();
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
