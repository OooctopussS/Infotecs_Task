using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infotecs.WebApi.Migrations
{
    public partial class changeTypeAndNameOfAllTimeColumnInResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllTimeSeconds",
                table: "Results");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AllTime",
                table: "Results",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllTime",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "AllTimeSeconds",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
