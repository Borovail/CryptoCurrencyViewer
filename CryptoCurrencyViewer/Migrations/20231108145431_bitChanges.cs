using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class bitChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketIdentifier",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_MarketIdentifier",
                table: "TickerCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList");

            migrationBuilder.DropColumn(
                name: "MarketIdentifier",
                table: "TickerCryptoList");

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "TickerCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "MarketList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MarketList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_MarketId",
                table: "TickerCryptoList",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList",
                column: "MarketId",
                principalTable: "MarketList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MarketList");

            migrationBuilder.AddColumn<string>(
                name: "MarketIdentifier",
                table: "TickerCryptoList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "MarketList",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList",
                column: "Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_MarketIdentifier",
                table: "TickerCryptoList",
                column: "MarketIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketIdentifier",
                table: "TickerCryptoList",
                column: "MarketIdentifier",
                principalTable: "MarketList",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
