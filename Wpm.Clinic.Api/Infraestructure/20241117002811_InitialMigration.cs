using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wpm.Clinic.Api.Infraestructure
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Clinic");

            migrationBuilder.CreateTable(
                name: "Consultation",
                schema: "Clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultationStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConsultationEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Diagnosis_Value = table.Column<string>(type: "TEXT", nullable: true),
                    Treatment_Value = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentWeight_Value = table.Column<decimal>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugAdministration",
                schema: "Clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DrugId_Value = table.Column<Guid>(type: "TEXT", nullable: false),
                    Dose_Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Dose_Unit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugAdministration", x => new { x.ConsultationId, x.Id });
                    table.ForeignKey(
                        name: "FK_DrugAdministration_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalSchema: "Clinic",
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VitalSigns",
                schema: "Clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReadingDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Temperature = table.Column<decimal>(type: "TEXT", nullable: false),
                    HeartRate = table.Column<int>(type: "INTEGER", nullable: false),
                    RespiratoryRate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSigns", x => new { x.ConsultationId, x.Id });
                    table.ForeignKey(
                        name: "FK_VitalSigns_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalSchema: "Clinic",
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugAdministration",
                schema: "Clinic");

            migrationBuilder.DropTable(
                name: "VitalSigns",
                schema: "Clinic");

            migrationBuilder.DropTable(
                name: "Consultation",
                schema: "Clinic");
        }
    }
}
