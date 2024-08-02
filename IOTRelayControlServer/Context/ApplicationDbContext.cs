using IOTRelayControlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace IOTRelayControlServer.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Sensor> Sensors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sensor>().HasQueryFilter(filter => !filter.IsDeleted);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
