using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class TotalChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullIndoCryptoList_DefaultCryptoModel_DefaultCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_FullIndoCryptoList_ExtendedCryptoModel_ExtendedCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoModel_FullIndoCryptoList_CryptoModelName",
                table: "TickerCryptoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoModel_MarketCryptoModel_MarketName",
                table: "TickerCryptoModel");

            migrationBuilder.DropTable(
                name: "GraphCryptoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TickerCryptoModel",
                table: "TickerCryptoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketCryptoModel",
                table: "MarketCryptoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullIndoCryptoList",
                table: "FullIndoCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_FullIndoCryptoList_DefaultCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_FullIndoCryptoList_ExtendedCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtendedCryptoModel",
                table: "ExtendedCryptoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultCryptoModel",
                table: "DefaultCryptoModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TickerCryptoModel");

            migrationBuilder.DropColumn(
                name: "DefaultCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.DropColumn(
                name: "ExtendedCryptoModelName",
                table: "FullIndoCryptoList");

            migrationBuilder.RenameTable(
                name: "TickerCryptoModel",
                newName: "TickerCryptoList");

            migrationBuilder.RenameTable(
                name: "MarketCryptoModel",
                newName: "MarketList");

            migrationBuilder.RenameTable(
                name: "FullIndoCryptoList",
                newName: "CryptoList");

            migrationBuilder.RenameTable(
                name: "ExtendedCryptoModel",
                newName: "ExtendedCryptoList");

            migrationBuilder.RenameTable(
                name: "DefaultCryptoModel",
                newName: "DefaultCryptoList");

            migrationBuilder.RenameTable(
                name: "ConvertedVolumeInfo",
                newName: "ConvertedVolumeList");

            migrationBuilder.RenameTable(
                name: "ConvertedLastInfo",
                newName: "ConvertedLastList");

            migrationBuilder.RenameColumn(
                name: "MarketName",
                table: "TickerCryptoList",
                newName: "MarketIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoModel_MarketName",
                table: "TickerCryptoList",
                newName: "IX_TickerCryptoList_MarketIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoModel_CryptoModelName",
                table: "TickerCryptoList",
                newName: "IX_TickerCryptoList_CryptoModelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ExtendedCryptoList",
                newName: "CryptoModelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DefaultCryptoList",
                newName: "CryptoModelName");

            migrationBuilder.AlterColumn<string>(
                name: "CryptoModelName",
                table: "TickerCryptoList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TickerId",
                table: "TickerCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ConvertedLastInfoId",
                table: "TickerCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "MarketList",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MarketList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ExtendedCryptoModelId",
                table: "ExtendedCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DefaultCryptoModelId",
                table: "DefaultCryptoList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ConvertedVolumeInfoId",
                table: "ConvertedVolumeList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ConvertedLastInfoId",
                table: "ConvertedLastList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TickerCryptoList",
                table: "TickerCryptoList",
                column: "TickerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList",
                column: "Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoList",
                table: "CryptoList",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtendedCryptoList",
                table: "ExtendedCryptoList",
                column: "ExtendedCryptoModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultCryptoList",
                table: "DefaultCryptoList",
                column: "DefaultCryptoModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConvertedVolumeList",
                table: "ConvertedVolumeList",
                column: "ConvertedVolumeInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConvertedLastList",
                table: "ConvertedLastList",
                column: "ConvertedLastInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList",
                column: "ConvertedLastInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                column: "ConvertedVolumeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoList_Name",
                table: "CryptoList",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedCryptoList_CryptoModelName",
                table: "ExtendedCryptoList",
                column: "CryptoModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultCryptoList_CryptoModelName",
                table: "DefaultCryptoList",
                column: "CryptoModelName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultCryptoList_CryptoList_CryptoModelName",
                table: "DefaultCryptoList",
                column: "CryptoModelName",
                principalTable: "CryptoList",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtendedCryptoList_CryptoList_CryptoModelName",
                table: "ExtendedCryptoList",
                column: "CryptoModelName",
                principalTable: "CryptoList",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_ConvertedLastList_ConvertedLastInfoId",
                table: "TickerCryptoList",
                column: "ConvertedLastInfoId",
                principalTable: "ConvertedLastList",
                principalColumn: "ConvertedLastInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_ConvertedVolumeList_ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                column: "ConvertedVolumeInfoId",
                principalTable: "ConvertedVolumeList",
                principalColumn: "ConvertedVolumeInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_CryptoList_CryptoModelName",
                table: "TickerCryptoList",
                column: "CryptoModelName",
                principalTable: "CryptoList",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketIdentifier",
                table: "TickerCryptoList",
                column: "MarketIdentifier",
                principalTable: "MarketList",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultCryptoList_CryptoList_CryptoModelName",
                table: "DefaultCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtendedCryptoList_CryptoList_CryptoModelName",
                table: "ExtendedCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_ConvertedLastList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_ConvertedVolumeList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_CryptoList_CryptoModelName",
                table: "TickerCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketIdentifier",
                table: "TickerCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TickerCryptoList",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketList",
                table: "MarketList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtendedCryptoList",
                table: "ExtendedCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_ExtendedCryptoList_CryptoModelName",
                table: "ExtendedCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultCryptoList",
                table: "DefaultCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_DefaultCryptoList_CryptoModelName",
                table: "DefaultCryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoList",
                table: "CryptoList");

            migrationBuilder.DropIndex(
                name: "IX_CryptoList_Name",
                table: "CryptoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConvertedVolumeList",
                table: "ConvertedVolumeList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConvertedLastList",
                table: "ConvertedLastList");

            migrationBuilder.DropColumn(
                name: "TickerId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "ExtendedCryptoModelId",
                table: "ExtendedCryptoList");

            migrationBuilder.DropColumn(
                name: "DefaultCryptoModelId",
                table: "DefaultCryptoList");

            migrationBuilder.DropColumn(
                name: "ConvertedVolumeInfoId",
                table: "ConvertedVolumeList");

            migrationBuilder.DropColumn(
                name: "ConvertedLastInfoId",
                table: "ConvertedLastList");

            migrationBuilder.RenameTable(
                name: "TickerCryptoList",
                newName: "TickerCryptoModel");

            migrationBuilder.RenameTable(
                name: "MarketList",
                newName: "MarketCryptoModel");

            migrationBuilder.RenameTable(
                name: "ExtendedCryptoList",
                newName: "ExtendedCryptoModel");

            migrationBuilder.RenameTable(
                name: "DefaultCryptoList",
                newName: "DefaultCryptoModel");

            migrationBuilder.RenameTable(
                name: "CryptoList",
                newName: "FullIndoCryptoList");

            migrationBuilder.RenameTable(
                name: "ConvertedVolumeList",
                newName: "ConvertedVolumeInfo");

            migrationBuilder.RenameTable(
                name: "ConvertedLastList",
                newName: "ConvertedLastInfo");

            migrationBuilder.RenameColumn(
                name: "MarketIdentifier",
                table: "TickerCryptoModel",
                newName: "MarketName");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoList_MarketIdentifier",
                table: "TickerCryptoModel",
                newName: "IX_TickerCryptoModel_MarketName");

            migrationBuilder.RenameIndex(
                name: "IX_TickerCryptoList_CryptoModelName",
                table: "TickerCryptoModel",
                newName: "IX_TickerCryptoModel_CryptoModelName");

            migrationBuilder.RenameColumn(
                name: "CryptoModelName",
                table: "ExtendedCryptoModel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CryptoModelName",
                table: "DefaultCryptoModel",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "CryptoModelName",
                table: "TickerCryptoModel",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TickerCryptoModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MarketCryptoModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "MarketCryptoModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DefaultCryptoModelName",
                table: "FullIndoCryptoList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtendedCryptoModelName",
                table: "FullIndoCryptoList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TickerCryptoModel",
                table: "TickerCryptoModel",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketCryptoModel",
                table: "MarketCryptoModel",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtendedCryptoModel",
                table: "ExtendedCryptoModel",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultCryptoModel",
                table: "DefaultCryptoModel",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullIndoCryptoList",
                table: "FullIndoCryptoList",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "GraphCryptoModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_FullIndoCryptoList_DefaultCryptoModelName",
                table: "FullIndoCryptoList",
                column: "DefaultCryptoModelName");

            migrationBuilder.CreateIndex(
                name: "IX_FullIndoCryptoList_ExtendedCryptoModelName",
                table: "FullIndoCryptoList",
                column: "ExtendedCryptoModelName");

            migrationBuilder.AddForeignKey(
                name: "FK_FullIndoCryptoList_DefaultCryptoModel_DefaultCryptoModelName",
                table: "FullIndoCryptoList",
                column: "DefaultCryptoModelName",
                principalTable: "DefaultCryptoModel",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_FullIndoCryptoList_ExtendedCryptoModel_ExtendedCryptoModelName",
                table: "FullIndoCryptoList",
                column: "ExtendedCryptoModelName",
                principalTable: "ExtendedCryptoModel",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoModel_FullIndoCryptoList_CryptoModelName",
                table: "TickerCryptoModel",
                column: "CryptoModelName",
                principalTable: "FullIndoCryptoList",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoModel_MarketCryptoModel_MarketName",
                table: "TickerCryptoModel",
                column: "MarketName",
                principalTable: "MarketCryptoModel",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
