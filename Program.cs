using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Agregar la configuración para usar una base de datos en memoria
builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/db", async ([FromServices] TareasContext db) =>
{
    db.Database.EnsureCreated(); // Asegura que la base de datos esté creada
    return Results.Ok($"Es base de datos en memoria: {db.Database.IsInMemory()}");
});

app.Run();
