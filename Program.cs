using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

// Configurar servicios en el contenedor.
builder.Services.Configure<TodoDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TodoDatabaseSettings)));

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("TodoDatabaseSettings:ConnectionString")));



builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IVisualizacionService, VisualizacionService>();


builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
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

app.Run();
