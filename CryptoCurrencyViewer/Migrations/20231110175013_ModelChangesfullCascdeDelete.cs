﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrencyViewer.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangesfullCascdeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_ConvertedLastList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_ConvertedVolumeList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "ConvertedLastInfoId",
                table: "TickerCryptoList");

            migrationBuilder.DropColumn(
                name: "ConvertedVolumeInfoId",
                table: "TickerCryptoList");

            migrationBuilder.AddColumn<int>(
                name: "TickerCryptoModelTickerId",
                table: "ConvertedVolumeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TickerId",
                table: "ConvertedVolumeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TickerId1",
                table: "ConvertedVolumeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TickerCryptoModelTickerId",
                table: "ConvertedLastList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TickerId",
                table: "ConvertedLastList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TickerId1",
                table: "ConvertedLastList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedVolumeList_TickerId",
                table: "ConvertedVolumeList",
                column: "TickerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedVolumeList_TickerId1",
                table: "ConvertedVolumeList",
                column: "TickerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedLastList_TickerId",
                table: "ConvertedLastList",
                column: "TickerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedLastList_TickerId1",
                table: "ConvertedLastList",
                column: "TickerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConvertedLastList_TickerCryptoList_TickerId",
                table: "ConvertedLastList",
                column: "TickerId",
                principalTable: "TickerCryptoList",
                principalColumn: "TickerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvertedLastList_TickerCryptoList_TickerId1",
                table: "ConvertedLastList",
                column: "TickerId1",
                principalTable: "TickerCryptoList",
                principalColumn: "TickerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvertedVolumeList_TickerCryptoList_TickerId",
                table: "ConvertedVolumeList",
                column: "TickerId",
                principalTable: "TickerCryptoList",
                principalColumn: "TickerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvertedVolumeList_TickerCryptoList_TickerId1",
                table: "ConvertedVolumeList",
                column: "TickerId1",
                principalTable: "TickerCryptoList",
                principalColumn: "TickerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList",
                column: "MarketId",
                principalTable: "MarketList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConvertedLastList_TickerCryptoList_TickerId",
                table: "ConvertedLastList");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvertedLastList_TickerCryptoList_TickerId1",
                table: "ConvertedLastList");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvertedVolumeList_TickerCryptoList_TickerId",
                table: "ConvertedVolumeList");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvertedVolumeList_TickerCryptoList_TickerId1",
                table: "ConvertedVolumeList");

            migrationBuilder.DropForeignKey(
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList");

            migrationBuilder.DropIndex(
                name: "IX_ConvertedVolumeList_TickerId",
                table: "ConvertedVolumeList");

            migrationBuilder.DropIndex(
                name: "IX_ConvertedVolumeList_TickerId1",
                table: "ConvertedVolumeList");

            migrationBuilder.DropIndex(
                name: "IX_ConvertedLastList_TickerId",
                table: "ConvertedLastList");

            migrationBuilder.DropIndex(
                name: "IX_ConvertedLastList_TickerId1",
                table: "ConvertedLastList");

            migrationBuilder.DropColumn(
                name: "TickerCryptoModelTickerId",
                table: "ConvertedVolumeList");

            migrationBuilder.DropColumn(
                name: "TickerId",
                table: "ConvertedVolumeList");

            migrationBuilder.DropColumn(
                name: "TickerId1",
                table: "ConvertedVolumeList");

            migrationBuilder.DropColumn(
                name: "TickerCryptoModelTickerId",
                table: "ConvertedLastList");

            migrationBuilder.DropColumn(
                name: "TickerId",
                table: "ConvertedLastList");

            migrationBuilder.DropColumn(
                name: "TickerId1",
                table: "ConvertedLastList");

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

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedLastInfoId",
                table: "TickerCryptoList",
                column: "ConvertedLastInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TickerCryptoList_ConvertedVolumeInfoId",
                table: "TickerCryptoList",
                column: "ConvertedVolumeInfoId");

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
                name: "FK_TickerCryptoList_MarketList_MarketId",
                table: "TickerCryptoList",
                column: "MarketId",
                principalTable: "MarketList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
