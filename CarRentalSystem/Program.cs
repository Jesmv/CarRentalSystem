using CarRentalSystem.Domain.Core.Services;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Domain.Interfaces.Services;
using CarRentalSystem.Infraestructure.Data;
using CarRentalSystem.Infraestructure.Data.Implementation;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalDbContext>
    (o => o.UseInMemoryDatabase("CarRental"));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

// Add services to the container.
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

app.MapGet("/Cars", (IInventoryService inventory) =>
{
    return inventory.GetAll();
})
.WithName("Cars Inventory")
.WithOpenApi();

app.MapGet("/AvailableCars", (IInventoryService inventory) =>
{
    return inventory.AvailableCars();
})
.WithName("Available Cars")
.WithOpenApi();

app.Run();
