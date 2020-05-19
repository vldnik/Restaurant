using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.implementation.Migrations
{
    public partial class DishChangePrepareTimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepareTime",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "PrepareTimeInMinutes",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepareTimeInMinutes",
                table: "Dishes");

            migrationBuilder.AddColumn<DateTime>(
                name: "PrepareTime",
                table: "Dishes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
