using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class Hystories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeHistoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CryptoModelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SearchTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeHistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeHistoryModel_CryptoList_CryptoModelName",
                        column: x => x.CryptoModelName,
                        principalTable: "CryptoList",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExchangeHistoryModel_UsersList_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchHistoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CryptoModelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SearchTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchHistoryModel_CryptoList_CryptoModelName",
                        column: x => x.CryptoModelName,
                        principalTable: "CryptoList",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchHistoryModel_UsersList_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeHistoryModel_CryptoModelName",
                table: "ExchangeHistoryModel",
                column: "CryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeHistoryModel_UserId",
                table: "ExchangeHistoryModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistoryModel_CryptoModelName",
                table: "SearchHistoryModel",
                column: "CryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistoryModel_UserId",
                table: "SearchHistoryModel",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeHistoryModel");

            migrationBuilder.DropTable(
                name: "SearchHistoryModel");
        }
    }
}
