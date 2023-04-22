using Microsoft.EntityFrameworkCore;
using serviceApi.context;
using serviceApi.interfaces;
using serviceApi.models;
using serviceApi.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ServicesDb>(opt =>
    opt.UseInMemoryDatabase("baseDb"));
builder.Services.AddScoped<IRepository<ServicesModel>, Repository<ServicesModel>>();
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
