using Core.Authentication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Authentication.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .HasColumnType("INT")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(u => u.Name)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            builder.Property(u => u.DateOfBirth)
                   .HasColumnType("DATETIME2")
                   .IsRequired();

            builder.Property(u => u.Phone)
                   .HasColumnType("VARCHAR(20)")
                   .IsRequired();

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .HasColumnType("VARCHAR(255)")
                     .IsRequired();
            });

            builder.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.Street)
                       .HasColumnName("Street")
                       .HasColumnType("VARCHAR(200)")
                       .IsRequired();

                address.Property(a => a.City)
                       .HasColumnName("City")
                       .HasColumnType("VARCHAR(100)")
                       .IsRequired();

                address.Property(a => a.State)
                       .HasColumnName("State")
                       .HasColumnType("VARCHAR(100)")
                       .IsRequired();

                address.Property(a => a.ZipCode)
                       .HasColumnName("ZipCode")
                       .HasColumnType("VARCHAR(20)")
                       .IsRequired();

                address.Property(a => a.Country)
                       .HasColumnName("Country")
                       .HasColumnType("VARCHAR(100)")
                       .IsRequired();
            });

            builder.OwnsOne(u => u.Password, pw =>
            {
                pw.Property(p => p.Hash)
                  .HasColumnName("PasswordHash")
                  .HasColumnType("VARCHAR(100)")
                  .IsRequired();
            });

            builder.Property(u => u.Role)
                   .HasConversion<string>()
                   .HasColumnName("Role")
                   .HasColumnType("VARCHAR(20)")
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.UpdatedAt)
                   .HasColumnType("DATETIME2")
                   .ValueGeneratedOnUpdate();

            builder.Property(u => u.DeletedAt)
                   .HasColumnType("DATETIME2");

            builder.Property(u => u.IsDeleted)
                   .HasColumnType("BIT")
                   .HasDefaultValue(false);
        }
    }
}
