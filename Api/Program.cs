using Data;
using Microsoft.EntityFrameworkCore;
using Repo.Interfaces;
using Repo.Services;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext < ApplicationContext > (options => options.UseNpgsql("Host=localhost;Port=5432;Database=BAVARIA;Username=postgres;Password=1"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Service Injected

builder.Services.AddScoped < IModelService, ModelService > ();
builder.Services.AddScoped < IModelOptionService, ModelOptionService > ();
builder.Services.AddScoped < ITypService, TypService > ();
builder.Services.AddScoped < IOptionService, OptionService > ();
builder.Services.AddScoped < IOptionTypeService, OptionTypeService > ();

#endregion

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