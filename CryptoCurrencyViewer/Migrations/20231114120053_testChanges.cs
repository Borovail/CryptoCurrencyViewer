using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class testChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCryptoList_UsersList_UserId",
                table: "DefaultCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCryptoList_UserId",
                table: "DefaultCryptoList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DefaultCryptoList");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CryptoList_UserId",
                table: "CryptoList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CryptoList_UsersList_UserId",
                table: "CryptoList",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserId",
                table: "ExchangeHistoryModel",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserId",
                table: "SearchHistoryModel",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CryptoList_UsersList_UserId",
                table: "CryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_CryptoList_UserId",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CryptoList");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserId",
                table: "ExchangeHistoryModel",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserId",
                table: "SearchHistoryModel",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
