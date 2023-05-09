using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingDataToOrdersAndOrderitemsAndTicketsAndTicketMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CVC", "CardNumber", "DeliveryAdress", "Email", "ExpireDate", "FirstName", "LastName", "ShippingRate", "TotalPriceEUR", "TotalPriceSEK" },
                values: new object[] { 1, "123", "1234567812345678", "Storgatan 1, 12345 Staden", "anna@exempel.com", "12/25", "Anna", "Andersson", 100m, 189.8m, 1898m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Title", "UserEmail" },
                values: new object[] { 1, "Jag undrar när min order kommer fram?", "Fraktfråga", "anna@exempel.com" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "TicketMessages",
                columns: new[] { "Id", "IsAdmin", "Text", "TicketId" },
                values: new object[,]
                {
                    { 1, true, "Hej, din order borde anlända inom 3-5 arbetsdagar.", 1 },
                    { 2, false, "Tack för informationen!", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
