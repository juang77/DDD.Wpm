using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wpm.Management.Api.Infraestructure
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Management");

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Weight_Value = table.Column<decimal>(type: "TEXT", nullable: true),
                    WeightClass = table.Column<int>(type: "INTEGER", nullable: false),
                    SexOfPet = table.Column<int>(type: "INTEGER", nullable: false),
                    BreedId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets",
                schema: "Management");
        }
    }
}
