using Api.Interfaces;
using Api.Mapper;
using Api.Services;
using Mapster;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBabyDevService, BabyDevService>();
builder.Services.AddScoped<IBabyDevDBClient, BabyDevDBClient>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMapster();

builder.Services.AddMappings();

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

// app.MapGet("/babydevforecast/{ageRangeStart}/{ageRangeEnd}", (IBabyDevService babyDevService, int ageRangeStart, int ageRangeEnd) =>
//     {
//         return babyDevService.GetBabyDev(ageRangeStart, ageRangeEnd);
//     })
//     .WithName("GetBabyDevForecast")
//     ;
app.Run();