using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bmo_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compressors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfFailures = table.Column<int>(type: "integer", nullable: true),
                    MaximumTemperature = table.Column<double>(type: "double precision", nullable: true),
                    MaximumVibration = table.Column<double>(type: "double precision", nullable: true),
                    LastMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OperatingTime = table.Column<double>(type: "double precision", nullable: true),
                    OilQuality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compressors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prensas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfFailures = table.Column<int>(type: "integer", nullable: true),
                    MaximumDistance = table.Column<double>(type: "double precision", nullable: true),
                    LastMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OperatingTime = table.Column<double>(type: "double precision", nullable: true),
                    OilQuality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prensas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompressorRunnings",
                columns: table => new
                {
                    RunningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompressorId = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: true),
                    Vibration = table.Column<double>(type: "double precision", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompressorRunnings", x => x.RunningId);
                    table.ForeignKey(
                        name: "FK_CompressorRunnings_Compressors_CompressorId",
                        column: x => x.CompressorId,
                        principalTable: "Compressors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrensaRunnings",
                columns: table => new
                {
                    RunningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrensaId = table.Column<int>(type: "integer", nullable: false),
                    DistanceTraveled = table.Column<double>(type: "double precision", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrensaRunnings", x => x.RunningId);
                    table.ForeignKey(
                        name: "FK_PrensaRunnings_Prensas_PrensaId",
                        column: x => x.PrensaId,
                        principalTable: "Prensas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompressorRunnings_CompressorId",
                table: "CompressorRunnings",
                column: "CompressorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrensaRunnings_PrensaId",
                table: "PrensaRunnings",
                column: "PrensaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompressorRunnings");

            migrationBuilder.DropTable(
                name: "PrensaRunnings");

            migrationBuilder.DropTable(
                name: "Compressors");

            migrationBuilder.DropTable(
                name: "Prensas");
        }
    }
}
