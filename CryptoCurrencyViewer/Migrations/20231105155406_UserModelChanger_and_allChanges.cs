using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class UserModelChanger_and_allChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MarketCap",
                table: "CryptoList",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CurrentPrice",
                table: "CryptoList",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "High24h",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Low24h",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxSupply",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceChangePercentage24h",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceChangePercentage7d",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalSupply",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume24h",
                table: "CryptoList",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoryList",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_HistoryList", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UsersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersList_Email",
                table: "UsersList",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryList");

            migrationBuilder.DropTable(
                name: "UsersList");

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

            migrationBuilder.AlterColumn<double>(
                name: "MarketCap",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CurrentPrice",
                table: "CryptoList",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
