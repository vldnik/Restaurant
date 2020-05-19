using Microsoft.EntityFrameworkCore.Migrations;

namespace data.implementation.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "PrepareTimeInMinutes", "Weight" },
                values: new object[] { 1, "A cup of water", 2, 0 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IsHard", "Name", "Quantity" },
                values: new object[] { 1, false, "Water", 500 });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
