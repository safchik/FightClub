using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasketItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_AspNetUsers_PlayerId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_PlayerId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "BasketItems");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CharacterId",
                table: "BasketItems",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Characters_CharacterId",
                table: "BasketItems",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Characters_CharacterId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CharacterId",
                table: "BasketItems");

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_PlayerId",
                table: "BasketItems",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_AspNetUsers_PlayerId",
                table: "BasketItems",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
