using HotelService.Shared.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper (scans the MappingProfile in the Shared project)
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

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
