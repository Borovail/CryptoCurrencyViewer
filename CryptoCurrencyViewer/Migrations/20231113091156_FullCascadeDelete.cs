using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class FullCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "TickerCryptoList",
                newName: "MarketCryptoModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoList_MarketId",
                table: "TickerCryptoList",
                newName: "IX_TickerCryptoList_MarketCryptoModelId");

            migrationBuilder.RenameColumn(
                name: "ConvertedVolumeInfoId",
                table: "ConvertedVolumeList",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ConvertedLastInfoId",
                table: "ConvertedLastList",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList",
                column: "ConvertedLastInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                column: "ConvertedVolumeInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketCryptoModelId",
                table: "TickerCryptoList",
                column: "MarketCryptoModelId",
                principalTable: "MarketList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketCryptoModelId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.RenameColumn(
                name: "MarketCryptoModelId",
                table: "TickerCryptoList",
                newName: "MarketId");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoList_MarketCryptoModelId",
                table: "TickerCryptoList",
                newName: "IX_TickerCryptoList_MarketId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConvertedVolumeList",
                newName: "ConvertedVolumeInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConvertedLastList",
                newName: "ConvertedLastInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList",
                column: "ConvertedLastInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                column: "ConvertedVolumeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList",
                column: "MarketId",
                principalTable: "MarketList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
