using Microsoft.EntityFrameworkCore;
using LeagueOfAPI.Models;
using LeagueOfAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AppDbContext<AppDbContext>(options => options.UseInMemoryDatabase("LeagueDb"));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Champions.AddRange(
        new Champion {id = 1, Name = "Ahri", Role = "Mage", Difficulty = 3 },
        new Champion {id = 2, Name = "Yasuo", Role = "Fighter", Difficulty = 5 },
        new Champion {id = 3, Name = "Thresh", Role = "Support", Difficulty = 4 }

    );
db.SaveChanges();
}

app.MapGet("/api/champions", async (AppDbContext db) =>
await db.Champions.ToListAsync());

app.MapGet("/api/champions/{id}", async (int id, AppDbContext db) =>
await db.Champions.FindAsync(id) is Champion champion ? Results.Ok(champion) : Results.NotFound());

app.MapPost("/api/champions", async (Champion champion, AppDbContext db) =>
{
    db.Champions.Add(champion);
    await db.SaveChangesAsync();
    return Results.Created($"/api/champions/{champion.Id}", champion);
});

app.MapPut("/api/champions/{id}", async (int id, Champion updatedChampion, AppDbContext db) =>
{
    var champion = await db.Champions.FindAsync(id);
    if (champion is null) return Results.NotFound();

    champion.Name = updatedChampion.Name;
    champion.Role = updatedChampion.Role;
    champion.Difficulty = updatedChampion.Difficulty;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/champions/{id}", async (int id, AppDbContext db) =>
{
    var champion = await db.Champions.FindAsync(id);
    if (champion is null) return Results.NotFound();

    db.Champions.Remove(champion);
    await db.SaveChangesAsync();
    return Results.NoContent();
})