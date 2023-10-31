using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "High24h",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Low24h",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxSupply",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceChangePercentage24h",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceChangePercentage7d",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSupply",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Volume24h",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "High24h",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "Low24h",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "MaxSupply",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "PriceChangePercentage24h",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "PriceChangePercentage7d",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "TotalSupply",
                table: "CryptoList");

            migrationBuilder.DropColumn(
                name: "Volume24h",
                table: "CryptoList");
        }
    }
}
