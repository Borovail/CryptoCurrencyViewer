using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchHistoryList",
                table: "SearchHistoryList");

            migrationBuilder.RenameTable(
                name: "SearchHistoryList",
                newName: "HistoryList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryList",
                table: "HistoryList",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryList",
                table: "HistoryList");

            migrationBuilder.RenameTable(
                name: "HistoryList",
                newName: "SearchHistoryList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchHistoryList",
                table: "SearchHistoryList",
                column: "Name");
        }
    }
}
