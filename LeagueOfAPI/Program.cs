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