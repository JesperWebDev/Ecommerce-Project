using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsAdminToTicketMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "TicketMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "TicketMessages");
        }
    }
}
