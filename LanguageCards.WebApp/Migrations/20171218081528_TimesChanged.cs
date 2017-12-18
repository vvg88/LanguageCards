using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LanguageCards.WebApp.Migrations
{
    public partial class TimesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "Statistics");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Statistics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFinish",
                table: "Statistics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "TimeFinish",
                table: "Statistics");

            migrationBuilder.AddColumn<long>(
                name: "BeginTime",
                table: "Statistics",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FinishTime",
                table: "Statistics",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
