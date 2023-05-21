using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Infra.Data.Contexts;
using FuelConsumptionApp.Infra.Data.Repositories;
using FuelConsumptionApp.Infra.Data.Services;
using FuelConsumptionApp.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;
DefaultDbContext.Configure(builder.Services, connectionString);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFuelConsumptionRepository, FuelConsumptionRepository>();
builder.Services.AddScoped<IFuelConsumptionService, FuelConsumptionService>();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Fuel Consumption API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();
app.MapControllers();

DefaultDbContext.InitializeDatabase(app.Services);
await DefaultDbContext.Seed(app.Services);

app.Run();
