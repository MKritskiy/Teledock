using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Teledock.DAL.Classes;
using Teledock.Database;
using Teledock.Filters;
using Teledock.Models;
using Teledock.Repositories.Interfaces;
using Teledock.Services.Classes;
using Teledock.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
});

builder.Services.AddDbContext<ClientContext>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IFounderRepository, FounderRepository>();

builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IRepository<Founder>, FounderRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFounderService, FounderService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Teledock API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teledock API v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
