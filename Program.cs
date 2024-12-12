using ConfigurationWebApiService.Controllers;
using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Services;
using ConfigurationWebApiService.Services.SignalR;
using ConfigurationWebApiService.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSignalR(hubOptions =>
    {
        hubOptions.EnableDetailedErrors = true;
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
    })
    .AddHubOptions<MessageForSubscribers>(options =>
    {
        options.EnableDetailedErrors = false;
        options.KeepAliveInterval = TimeSpan.FromMinutes(5);
    });

builder.Services.AddSqlServer<ConfugurationManagerDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

//builder.Services.AddDbContext<ConfugurationManagerDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});
builder.Services.AddScoped<ConfugurationManagerDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();

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
