using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bmo_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vibration",
                table: "Vibration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distance",
                table: "Distance");

            migrationBuilder.RenameColumn(
                name: "typeError",
                table: "Runnings",
                newName: "typeerror");

            migrationBuilder.RenameColumn(
                name: "meanVibration",
                table: "Runnings",
                newName: "meanvibration");

            migrationBuilder.RenameColumn(
                name: "meanTemperature",
                table: "Runnings",
                newName: "meantemperature");

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "Vibration",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "Temperature",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "Distance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vibration",
                table: "Vibration",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distance",
                table: "Distance",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Vibration_id_running",
                table: "Vibration",
                column: "id_running");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_id_running",
                table: "Temperature",
                column: "id_running");

            migrationBuilder.CreateIndex(
                name: "IX_Distance_id_running",
                table: "Distance",
                column: "id_running");

            migrationBuilder.AddForeignKey(
                name: "FK_Distance_Runnings_id_running",
                table: "Distance",
                column: "id_running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperature_Runnings_id_running",
                table: "Temperature",
                column: "id_running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vibration_Runnings_id_running",
                table: "Vibration",
                column: "id_running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distance_Runnings_id_running",
                table: "Distance");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperature_Runnings_id_running",
                table: "Temperature");

            migrationBuilder.DropForeignKey(
                name: "FK_Vibration_Runnings_id_running",
                table: "Vibration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vibration",
                table: "Vibration");

            migrationBuilder.DropIndex(
                name: "IX_Vibration_id_running",
                table: "Vibration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature");

            migrationBuilder.DropIndex(
                name: "IX_Temperature_id_running",
                table: "Temperature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distance",
                table: "Distance");

            migrationBuilder.DropIndex(
                name: "IX_Distance_id_running",
                table: "Distance");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Vibration");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Temperature");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Distance");

            migrationBuilder.RenameColumn(
                name: "typeerror",
                table: "Runnings",
                newName: "typeError");

            migrationBuilder.RenameColumn(
                name: "meanvibration",
                table: "Runnings",
                newName: "meanVibration");

            migrationBuilder.RenameColumn(
                name: "meantemperature",
                table: "Runnings",
                newName: "meanTemperature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vibration",
                table: "Vibration",
                columns: new[] { "id_running", "timestamp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature",
                columns: new[] { "id_running", "timestamp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distance",
                table: "Distance",
                columns: new[] { "id_running", "timestamp" });
        }
    }
}
