using Microsoft.EntityFrameworkCore;
using LeagueOfAPI.Models;

namespace LeagueOfAPI.Data;

public class AppDbContext : AppDbContext
{
    public DbSet<Champion> Champions { get; set; }

    public AppDbContext(AppDbContextOptions<AppDbContext> options) : base(options) { }
}