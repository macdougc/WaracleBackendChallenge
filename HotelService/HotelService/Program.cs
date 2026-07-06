using HotelService.Filters;
using HotelService.Services;
using HotelService.Shared.Data;
using HotelService.Shared.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper (scans the MappingProfile in the Shared project)
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register DbContext (reads connection string from configuration)
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HotelDBContext>();

// Register application services
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService.Services.HotelService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionActionFilter)));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
