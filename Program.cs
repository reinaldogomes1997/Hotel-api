using HotelApi.Data;
using HotelApi.Interfaces;
using HotelApi.Repositories;
using HotelApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 🔥 CORREÇÃO PRINCIPAL (evita loop infinito / erro 500)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IQuartoRepository, QuartoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); // 👈 garante cliente

// Services
builder.Services.AddScoped<IQuartoService, QuartoService>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IClienteService, ClienteService>(); // 👈 garante cliente

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelDb;Trusted_Connection=True;"));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
