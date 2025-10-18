using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightClub.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePlayerCharacterRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveCharacterId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActiveCharacterId",
                table: "AspNetUsers",
                column: "ActiveCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Characters_ActiveCharacterId",
                table: "AspNetUsers",
                column: "ActiveCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Characters_ActiveCharacterId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActiveCharacterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ActiveCharacterId",
                table: "AspNetUsers");
        }
    }
}
