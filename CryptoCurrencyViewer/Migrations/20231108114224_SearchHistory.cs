using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class SearchHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "DefaultCryptoList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DefaultCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCryptoList_UserId",
                table: "DefaultCryptoList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCryptoList_UsersList_UserId",
                table: "DefaultCryptoList",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCryptoList_UsersList_UserId",
                table: "DefaultCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCryptoList_UserId",
                table: "DefaultCryptoList");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "DefaultCryptoList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DefaultCryptoList");
        }
    }
}
