using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingDataToCategoriesAndProductsAndTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Herrkläder" },
                    { 2, "Damkläder" },
                    { 3, "Accessoarer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "PriceEUR", "PriceSEK" },
                values: new object[,]
                {
                    { 1, "Snygg kavaj för herr", "https://via.placeholder.com/300x200", "Kavaj", 99.9m, 999m },
                    { 2, "Elegant klänning för dam", "https://via.placeholder.com/300x200", "Klänning", 89.9m, 899m },
                    { 3, "Snyggt skärp i läder", "https://via.placeholder.com/300x200", "Skärp", 29.9m, 299m },
                    { 4, "Dessa snygga herrshorts är perfekta för en avslappnad sommarstil.", "https://via.placeholder.com/300x200", "Shorts", 79.9m, 799m }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "VÅRREA" },
                    { 2, "Höstmode" },
                    { 3, "Fest" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductTag",
                columns: new[] { "ProductsId", "TagsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductTag",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductTag",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductTag",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductTag",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTag",
                keyColumns: new[] { "ProductsId", "TagsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
