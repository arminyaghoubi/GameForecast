using Match.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Infrastructure.Persistence.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Domain.Entities.Match>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Match> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Match));

        builder.Property(m => m.MatchTime)
            .IsRequired();

        builder.Property(m => m.Status)
            .HasConversion<byte>()
            .IsRequired();

        builder.HasOne(m => m.HomeTeam)
            .WithMany(t => t.HomeMatches)
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.AwayTeam)
            .WithMany(t => t.AwayMatches)
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}