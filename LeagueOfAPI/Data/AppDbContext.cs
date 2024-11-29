using Microsoft.EntityFrameworkCore;
using LeagueOfAPI.Models;

namespace LeagueOfAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Champion> Champions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
