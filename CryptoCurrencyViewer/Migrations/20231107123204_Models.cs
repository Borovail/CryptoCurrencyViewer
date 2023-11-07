using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoList");

            migrationBuilder.DropTable(
                name: "HistoryList");

            migrationBuilder.CreateTable(
                name: "ConvertedLastInfo",
                columns: table => new
                {
                    Usd = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ConvertedVolumeInfo",
                columns: table => new
                {
                    Usd = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DefaultCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCryptoModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ExtendedCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceChangePercentage24h = table.Column<double>(type: "float", nullable: true),
                    Volume24h = table.Column<double>(type: "float", nullable: true),
                    High24h = table.Column<double>(type: "float", nullable: true),
                    Low24h = table.Column<double>(type: "float", nullable: true),
                    PriceChangePercentage7d = table.Column<double>(type: "float", nullable: true),
                    TotalSupply = table.Column<double>(type: "float", nullable: true),
                    MaxSupply = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedCryptoModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "GraphCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MarketCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketCryptoModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "FullIndoCryptoList",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DefaultCryptoModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExtendedCryptoModelName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullIndoCryptoList", x => x.Name);
                    table.ForeignKey(
                        name: "FK_FullIndoCryptoList_DefaultCryptoModel_DefaultCryptoModelName",
                        column: x => x.DefaultCryptoModelName,
                        principalTable: "DefaultCryptoModel",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_FullIndoCryptoList_ExtendedCryptoModel_ExtendedCryptoModelName",
                        column: x => x.ExtendedCryptoModelName,
                        principalTable: "ExtendedCryptoModel",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "TickerCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CryptoModelName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickerCryptoModel", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TickerCryptoModel_FullIndoCryptoList_CryptoModelName",
                        column: x => x.CryptoModelName,
                        principalTable: "FullIndoCryptoList",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_TickerCryptoModel_MarketCryptoModel_MarketName",
                        column: x => x.MarketName,
                        principalTable: "MarketCryptoModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FullIndoCryptoList_DefaultCryptoModelName",
                table: "FullIndoCryptoList",
                column: "DefaultCryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_FullIndoCryptoList_ExtendedCryptoModelName",
                table: "FullIndoCryptoList",
                column: "ExtendedCryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoModel_CryptoModelName",
                table: "TickerCryptoModel",
                column: "CryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoModel_MarketName",
                table: "TickerCryptoModel",
                column: "MarketName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvertedLastInfo");

            migrationBuilder.DropTable(
                name: "ConvertedVolumeInfo");

            migrationBuilder.DropTable(
                name: "GraphCryptoModel");

            migrationBuilder.DropTable(
                name: "TickerCryptoModel");

            migrationBuilder.DropTable(
                name: "FullIndoCryptoList");

            migrationBuilder.DropTable(
                name: "MarketCryptoModel");

            migrationBuilder.DropTable(
                name: "DefaultCryptoModel");

            migrationBuilder.DropTable(
                name: "ExtendedCryptoModel");

            migrationBuilder.CreateTable(
                name: "CryptoList",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: true),
                    High24h = table.Column<double>(type: "float", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Low24h = table.Column<double>(type: "float", nullable: true),
                    MarketCap = table.Column<double>(type: "float", nullable: true),
                    MaxSupply = table.Column<double>(type: "float", nullable: true),
                    PriceChangePercentage24h = table.Column<double>(type: "float", nullable: true),
                    PriceChangePercentage7d = table.Column<double>(type: "float", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSupply = table.Column<double>(type: "float", nullable: true),
                    Volume24h = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoList", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "HistoryList",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: true),
                    High24h = table.Column<double>(type: "float", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Low24h = table.Column<double>(type: "float", nullable: true),
                    MarketCap = table.Column<double>(type: "float", nullable: true),
                    MaxSupply = table.Column<double>(type: "float", nullable: true),
                    PriceChangePercentage24h = table.Column<double>(type: "float", nullable: true),
                    PriceChangePercentage7d = table.Column<double>(type: "float", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSupply = table.Column<double>(type: "float", nullable: true),
                    Volume24h = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryList", x => x.Name);
                });
        }
    }
}
