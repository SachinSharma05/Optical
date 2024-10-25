using api;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Create an instance of the Startup class
var startup = new Startup(builder.Configuration);

// Call the ConfigureServices method on the Startup instance
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Call the Configure method on the Startup instance
startup.Configure(app, app.Environment);

app.Run();