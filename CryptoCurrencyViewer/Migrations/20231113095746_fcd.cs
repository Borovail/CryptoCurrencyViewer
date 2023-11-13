using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class fcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_MarketCryptoModelId",
                table: "TickerCryptoList");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_MarketCryptoModelId",
                table: "TickerCryptoList",
                column: "MarketCryptoModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_MarketCryptoModelId",
                table: "TickerCryptoList");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_MarketCryptoModelId",
                table: "TickerCryptoList",
                column: "MarketCryptoModelId");
        }
    }
}
