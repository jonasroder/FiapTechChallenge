using Core.Gaming.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Gaming.Persistence.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
               .HasColumnType("INT")
               .ValueGeneratedOnAdd()
               .UseIdentityColumn();

        builder.Property(g => g.Title)
               .HasColumnType("VARCHAR(200)")
               .IsRequired();

        builder.Property(g => g.Description)
               .HasColumnType("TEXT");

        builder.Property(g => g.ImageUrl)
               .HasColumnType("VARCHAR(500)");

        builder.Property(g => g.Rating)
               .HasColumnType("DECIMAL(3,2)");

        builder.Property(g => g.ReleaseDate)
               .HasColumnType("DATE")
               .IsRequired();

        builder.Property(g => g.IsAvailable)
               .HasColumnType("BIT")
               .IsRequired();

        // Auditing
        builder.Property(g => g.CreatedAt).HasColumnType("DATETIME2").IsRequired();
        builder.Property(g => g.UpdatedAt).HasColumnType("DATETIME2");
        builder.Property(g => g.DeletedAt).HasColumnType("DATETIME2");
        builder.Property(g => g.IsDeleted).HasColumnType("BIT").HasDefaultValue(false);
    }
}
