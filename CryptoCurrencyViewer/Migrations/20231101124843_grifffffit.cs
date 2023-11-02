using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class grifffffit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CryptoList");

            migrationBuilder.CreateTable(
                name: "SearchHistoryList",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    PriceChangePercentage24h = table.Column<double>(type: "float", nullable: false),
                    Volume24h = table.Column<double>(type: "float", nullable: false),
                    High24h = table.Column<double>(type: "float", nullable: false),
                    Low24h = table.Column<double>(type: "float", nullable: false),
                    PriceChangePercentage7d = table.Column<double>(type: "float", nullable: false),
                    TotalSupply = table.Column<double>(type: "float", nullable: false),
                    MaxSupply = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistoryList", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchHistoryList");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CryptoList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
