using Core.Gaming.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Gaming.Persistence.Configurations;

public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
{
    public void Configure(EntityTypeBuilder<GameGenre> builder)
    {
        builder.ToTable("GameGenres");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
               .HasColumnType("INT")
               .ValueGeneratedOnAdd()
               .UseIdentityColumn();

        builder.Property(g => g.Name)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

        builder.HasOne(g => g.Game)
               .WithMany(gm => gm.Genres)
               .HasForeignKey(g => g.GameId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
