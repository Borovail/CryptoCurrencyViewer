using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class RevertChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserModelId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserModelId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_SearchHistoryModel_UserModelId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeHistoryModel_UserModelId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "SearchHistoryModel");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "ExchangeHistoryModel");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SearchHistoryModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExchangeHistoryModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistoryModel_UserId",
                table: "SearchHistoryModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeHistoryModel_UserId",
                table: "ExchangeHistoryModel",
                column: "UserId");

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
                name: "FK_ExchangeHistoryModel_UsersList_UserId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_SearchHistoryModel_UserId",
                table: "SearchHistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeHistoryModel_UserId",
                table: "ExchangeHistoryModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SearchHistoryModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExchangeHistoryModel");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "SearchHistoryModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "ExchangeHistoryModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistoryModel_UserModelId",
                table: "SearchHistoryModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeHistoryModel_UserModelId",
                table: "ExchangeHistoryModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeHistoryModel_UsersList_UserModelId",
                table: "ExchangeHistoryModel",
                column: "UserModelId",
                principalTable: "UsersList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryModel_UsersList_UserModelId",
                table: "SearchHistoryModel",
                column: "UserModelId",
                principalTable: "UsersList",
                principalColumn: "Id");
        }
    }
}
