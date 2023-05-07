using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingTotalPriceEURtoOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalPriceSEK");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceEUR",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceEUR",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPriceSEK",
                table: "Orders",
                newName: "TotalPrice");
        }
    }
}
