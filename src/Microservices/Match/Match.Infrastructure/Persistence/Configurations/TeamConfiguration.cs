using Match.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable(nameof(Team));

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Image)
            .HasMaxLength(256);

        builder.HasData(
            new Team(1, "Mexico", "/image/team/Mexico.png"),
            new Team(2, "South Africa", "/image/team/SouthAfrica.png"),
            new Team(3, "Canada", "/image/team/Canada.png"),
            new Team(4, "Bosnia", "/image/team/Bosnia.png"),
            new Team(5, "Qatar", "/image/team/Qatar.png"),
            new Team(6, "Switzerland", "/image/team/Switzerland.png"));
    }
}
