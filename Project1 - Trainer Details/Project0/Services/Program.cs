using BusinessLogic;
using Data__FluentApi;
using Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("TrainerDB");
builder.Services.AddDbContext<TrainerContext>(options=>options.UseSqlServer(config));
builder.Services.AddScoped<ITrainerRepo, FluentMethods>();
builder.Services.AddScoped<ITrainerLogic, logic>();

builder.Services.AddScoped<ISkillRepo, FluentMethods>();
builder.Services.AddScoped<ISkillLogic, logic>();

builder.Services.AddScoped<IAchivementsRepo, FluentMethods>();
builder.Services.AddScoped<IAchivemensLogic, logic>();

builder.Services.AddScoped<IEducationRepo, FluentMethods>();
builder.Services.AddScoped<IEducationLogic, logic>();

builder.Services.AddScoped<Validation, Validation>();




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
