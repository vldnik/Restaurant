using Microsoft.EntityFrameworkCore.Migrations;

namespace data.implementation.Migrations
{
    public partial class PriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Weight" },
                values: new object[] { 99.99m, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "PrepareTimeInMinutes", "Price", "Weight" },
                values: new object[] { 2, "slice of bread", 10, 29.99m, 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IsHard", "Name", "Quantity" },
                values: new object[] { 2, false, "Bread", 200 });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Weight",
                value: 0);
        }
    }
}
