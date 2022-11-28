using CtcontrolAPIService.Models;
using CtcontrolAPIService.Services;
using Microsoft.Extensions.Hosting.WindowsServices;
using System.Diagnostics;

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseWindowsService();

var app = builder.Build();
app.UseSwaggerUI();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.UseSwagger(x => x.SerializeAsV2 = true);

app.Run();
