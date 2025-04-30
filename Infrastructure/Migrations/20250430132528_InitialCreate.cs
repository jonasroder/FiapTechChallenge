using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
