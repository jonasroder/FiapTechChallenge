using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Mapeia para tabela "Users"
        builder.ToTable("Users");

        // Chave primária
        builder.HasKey(u => u.Id);

        // Propriedades básicas
        builder.Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.DateOfBirth)
               .IsRequired();

        builder.Property(u => u.Phone)
               .IsRequired()
               .HasMaxLength(20);

        // Value Object: Email
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                 .HasColumnName("Email")
                 .IsRequired()
                 .HasMaxLength(255);
        });

        // Value Object: Address
        builder.OwnsOne(u => u.Address, address =>
        {
            address.Property(a => a.Street)
                   .HasColumnName("Street")
                   .IsRequired()
                   .HasMaxLength(200);

            address.Property(a => a.City)
                   .HasColumnName("City")
                   .IsRequired()
                   .HasMaxLength(100);

            address.Property(a => a.State)
                   .HasColumnName("State")
                   .IsRequired()
                   .HasMaxLength(100);

            address.Property(a => a.ZipCode)
                   .HasColumnName("ZipCode")
                   .IsRequired()
                   .HasMaxLength(20);

            address.Property(a => a.Country)
                   .HasColumnName("Country")
                   .IsRequired()
                   .HasMaxLength(100);
        });

        // Value Object: Password (hash)
        builder.OwnsOne(u => u.Password, pw =>
        {
            pw.Property(p => p.Hash)
              .HasColumnName("PasswordHash")
              .IsRequired();
        });

        // Enum: armazena como string para legibilidade
        builder.Property(u => u.Role)
               .HasConversion<string>()
               .HasColumnName("Role")
               .IsRequired();

        // Campos de auditoria
        builder.Property(u => u.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAdd();

        builder.Property(u => u.UpdatedAt)
               .ValueGeneratedOnUpdate();

        builder.Property(u => u.IsDeleted)
               .HasDefaultValue(false);
    }
}
