using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bmo_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeSeriesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distance",
                columns: table => new
                {
                    id_running = table.Column<long>(type: "bigint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    distance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => new { x.id_running, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    needFix = table.Column<bool>(type: "boolean", nullable: false),
                    maxTemperature = table.Column<float>(type: "real", nullable: false),
                    maxVibration = table.Column<float>(type: "real", nullable: false),
                    oil_quality = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Runnings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_running = table.Column<long>(type: "bigint", nullable: false),
                    typeError = table.Column<string>(type: "text", nullable: false),
                    meanTemperature = table.Column<float>(type: "real", nullable: false),
                    meanVibration = table.Column<float>(type: "real", nullable: false),
                    start_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runnings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    id_running = table.Column<long>(type: "bigint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    temperature = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => new { x.id_running, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "Vibration",
                columns: table => new
                {
                    id_running = table.Column<long>(type: "bigint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vibration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vibration", x => new { x.id_running, x.timestamp });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distance");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Runnings");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Vibration");
        }
    }
}
