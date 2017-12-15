using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LanguageCards.WebApp.Migrations
{
    public partial class StatWithCardProg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Cards_CardId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_CardId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Statistics");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Statistics",
                newName: "CardProgressId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                newName: "IX_Statistics_CardProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_CardProgresses_CardProgressId",
                table: "Statistics",
                column: "CardProgressId",
                principalTable: "CardProgresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_CardProgresses_CardProgressId",
                table: "Statistics");

            migrationBuilder.RenameColumn(
                name: "CardProgressId",
                table: "Statistics",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_CardProgressId",
                table: "Statistics",
                newName: "IX_Statistics_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Statistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CardId",
                table: "Statistics",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Cards_CardId",
                table: "Statistics",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_AspNetUsers_UserId",
                table: "Statistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
