using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightClub.Migrations
{
    /// <inheritdoc />
    public partial class AddManaToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentMana",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mana",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 1,
                column: "Mana",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 2,
                column: "Mana",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 3,
                column: "Mana",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 4,
                column: "Mana",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 5,
                column: "Mana",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 6,
                column: "Mana",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMana",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Mana",
                table: "Characters");

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 1,
                column: "Mana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 2,
                column: "Mana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 3,
                column: "Mana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 4,
                column: "Mana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 5,
                column: "Mana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RaceStats",
                keyColumn: "Id",
                keyValue: 6,
                column: "Mana",
                value: 0);
        }
    }
}
