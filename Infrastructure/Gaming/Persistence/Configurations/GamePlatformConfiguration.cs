using Core.Gaming.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Gaming.Persistence.Configurations;

public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatform>
{
    public void Configure(EntityTypeBuilder<GamePlatform> builder)
    {
        builder.ToTable("GamePlatforms");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
               .HasColumnType("INT")
               .ValueGeneratedOnAdd()
               .UseIdentityColumn();

        builder.Property(p => p.Name)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

        builder.HasOne(p => p.Game)
               .WithMany(g => g.Platforms)
               .HasForeignKey(p => p.GameId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
