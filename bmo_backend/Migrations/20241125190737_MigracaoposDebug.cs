using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bmo_backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoposDebug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "id_running",
                table: "Vibration",
                newName: "id_Running");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Vibration",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Vibration_id_running",
                table: "Vibration",
                newName: "IX_Vibration_id_Running");

            migrationBuilder.RenameColumn(
                name: "id_running",
                table: "Temperature",
                newName: "id_Running");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Temperature",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Temperature_id_running",
                table: "Temperature",
                newName: "IX_Temperature_id_Running");

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

            migrationBuilder.RenameColumn(
                name: "id_running",
                table: "Runnings",
                newName: "id_Machine");

            migrationBuilder.RenameColumn(
                name: "id_running",
                table: "Distance",
                newName: "id_Running");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Distance",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Distance_id_running",
                table: "Distance",
                newName: "IX_Distance_id_Running");

            migrationBuilder.AlterColumn<string>(
                name: "typeError",
                table: "Runnings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<float>(
                name: "meanVibration",
                table: "Runnings",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "meanTemperature",
                table: "Runnings",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_timestamp",
                table: "Runnings",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<float>(
                name: "distanceTraveled",
                table: "Runnings",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "type",
                table: "Machines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "maxVibration",
                table: "Machines",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "maxTemperature",
                table: "Machines",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Machines",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Machines",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<float>(
                name: "maxDistanceTraveled",
                table: "Machines",
                type: "real",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runnings_id_Machine",
                table: "Runnings",
                column: "id_Machine");

            migrationBuilder.AddForeignKey(
                name: "FK_Distance_Runnings_id_Running",
                table: "Distance",
                column: "id_Running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Runnings_Machines_id_Machine",
                table: "Runnings",
                column: "id_Machine",
                principalTable: "Machines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperature_Runnings_id_Running",
                table: "Temperature",
                column: "id_Running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vibration_Runnings_id_Running",
                table: "Vibration",
                column: "id_Running",
                principalTable: "Runnings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distance_Runnings_id_Running",
                table: "Distance");

            migrationBuilder.DropForeignKey(
                name: "FK_Runnings_Machines_id_Machine",
                table: "Runnings");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperature_Runnings_id_Running",
                table: "Temperature");

            migrationBuilder.DropForeignKey(
                name: "FK_Vibration_Runnings_id_Running",
                table: "Vibration");

            migrationBuilder.DropIndex(
                name: "IX_Runnings_id_Machine",
                table: "Runnings");

            migrationBuilder.DropColumn(
                name: "distanceTraveled",
                table: "Runnings");

            migrationBuilder.DropColumn(
                name: "maxDistanceTraveled",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "id_Running",
                table: "Vibration",
                newName: "id_running");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vibration",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Vibration_id_Running",
                table: "Vibration",
                newName: "IX_Vibration_id_running");

            migrationBuilder.RenameColumn(
                name: "id_Running",
                table: "Temperature",
                newName: "id_running");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Temperature",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Temperature_id_Running",
                table: "Temperature",
                newName: "IX_Temperature_id_running");

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

            migrationBuilder.RenameColumn(
                name: "id_Machine",
                table: "Runnings",
                newName: "id_running");

            migrationBuilder.RenameColumn(
                name: "id_Running",
                table: "Distance",
                newName: "id_running");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Distance",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Distance_id_Running",
                table: "Distance",
                newName: "IX_Distance_id_running");

            migrationBuilder.AlterColumn<string>(
                name: "typeerror",
                table: "Runnings",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "meanvibration",
                table: "Runnings",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "meantemperature",
                table: "Runnings",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_timestamp",
                table: "Runnings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "type",
                table: "Machines",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "maxVibration",
                table: "Machines",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "maxTemperature",
                table: "Machines",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Machines",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "Machines",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
    }
}
