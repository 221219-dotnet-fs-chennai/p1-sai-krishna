global using Serilog;
using BusinessLogic;
using Data__FluentApi;
using Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
        )
    );
// Add services to the container.
Log.Logger = new LoggerConfiguration()
            .WriteTo.File(@"Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();
Log.Information("Program Starts");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("TrainerDB");
builder.Services.AddDbContext<TrainerContext>(options=>options.UseSqlServer(config));
builder.Services.AddScoped<ITrainerRepo, EFRepo>();
builder.Services.AddScoped<ITrainerLogic, logic>();

builder.Services.AddScoped<ISkillRepo, EFRepo>();
builder.Services.AddScoped<ISkillLogic, logic>();

builder.Services.AddScoped<IAchivementsRepo, EFRepo>();
builder.Services.AddScoped<IAchivemensLogic, logic>();

builder.Services.AddScoped<IEducationRepo, EFRepo>();
builder.Services.AddScoped<IEducationLogic, logic>();

builder.Services.AddScoped<IExperienceRepo, EFRepo>();
builder.Services.AddScoped<IExperienceLogic, logic>();

builder.Services.AddScoped<IAdminRepo, EFAdminRepo>();
builder.Services.AddScoped<IAdminLogic, AdminLogic>();

builder.Services.AddScoped<Validation, Validation>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
