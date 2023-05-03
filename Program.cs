global using d_Videogame_Store.Models;
global using d_Videogame_Store.Services.ClientService;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Videogame Store API (ASP.NET Core 7)",
            Description = "An ASP.NET Core Web API for managing a videogame rental store.",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Victor Raul Medina Meza",
                Url = new Uri("https://github.com/vrmedina")
            },
            License = new OpenApiLicense
            {
                Name = "Project License",
                Url = new Uri("https://example.com/license")
            }
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });
builder.Services.AddScoped<IClientService, ClientService>();


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
