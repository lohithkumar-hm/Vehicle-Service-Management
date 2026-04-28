using Microsoft.EntityFrameworkCore;
using TestBackend.Mappers;
using TestBackend.Model.Context;
using TestBackend.Model.Repository.Abstraction;
using TestBackend.Model.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddAutoMapper(option => option.AddProfile<MappingProfile>());

builder
    .Services
    .AddScoped<IVRepository, VehicleRepository>();

builder
    .Services
    .AddScoped<ISRepository, ServiceVRepository>();

builder
    .Services
    .AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConStr")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
