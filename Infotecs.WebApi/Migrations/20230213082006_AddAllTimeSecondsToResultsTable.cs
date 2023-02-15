using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infotecs.WebApi.Migrations
{
    public partial class AddAllTimeSecondsToResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllTimeSeconds",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllTimeSeconds",
                table: "Results");
        }
    }
}
