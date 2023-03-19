using Desapego.API.Models.Configuration;
using Desapego.API.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DesapegoStoreSettings>(
    builder.Configuration.GetSection("DesapegoStoreDatabase"));

builder.Services.AddSingleton<ProductServiceRepository>();

var app = builder.Build();
app.Run();