using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data;

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Platform> Platform { get; set; }
}