using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Agregar la configuraci�n para usar una base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));

// Agregar la configuraci�n para usar una base de datos SQL Server
// CAMBIAR EL password y Source por los valores de tu conexi�n
builder.Services.AddDbContext<TareasContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/db", async ([FromServices] TareasContext db) =>
{
    db.Database.EnsureCreated(); // Asegura que la base de datos est� creada
    return Results.Ok($"Es base de datos en memoria: {db.Database.IsInMemory()}");
});

app.Run();
