using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project.Migrations
{
    /// <inheritdoc />
    public partial class RenamePriceToPriceSEKInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PriceSEK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceSEK",
                table: "Products",
                newName: "Price");
        }
    }
}
