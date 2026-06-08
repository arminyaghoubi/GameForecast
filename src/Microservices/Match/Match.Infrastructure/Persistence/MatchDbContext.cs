using Match.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.Persistence;

public class MatchDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Domain.Entities.Match> Matches { get; set; }

    public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatchDbContext).Assembly);
    }
}
