using System.Reflection;
using System.Xml;
using Df.ApiExceptionMiddleware;
using log4net;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net("log4net.config");

var log4NetConfiguration = new XmlDocument();
log4NetConfiguration.Load(File.OpenRead("log4net.config"));
var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
log4net.Config.XmlConfigurator.Configure(repo, log4NetConfiguration["log4net"]);

builder.Services.AddControllers();

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

app.UseApiExceptionMiddleware();

app.Run();