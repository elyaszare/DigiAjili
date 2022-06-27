using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EFCore.Migrations
{
    public partial class InventoryOperationEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Count",
                table: "InventoryOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrentCount",
                table: "InventoryOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InventoryOperations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Operation",
                table: "InventoryOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OperatorId",
                table: "InventoryOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "InventoryOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "CurrentCount",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "InventoryOperations");
        }
    }
}
