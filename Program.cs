using CtcontrolAPIService.Models;
using CtcontrolAPIService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwaggerUI();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.UseSwagger(x => x.SerializeAsV2 = true);

app.Run();
