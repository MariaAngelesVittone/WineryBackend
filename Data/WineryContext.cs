using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class WineryContext : DbContext
{
    public WineryContext(DbContextOptions<WineryContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Wine> Wines { get; set; }
    public DbSet<Tasting> Tastings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}