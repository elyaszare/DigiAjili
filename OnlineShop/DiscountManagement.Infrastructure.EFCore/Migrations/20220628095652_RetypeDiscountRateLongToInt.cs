using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManagement.Infrastructure.EFCore.Migrations
{
    public partial class RetypeDiscountRateLongToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<int>(
                name: "DiscountRate",
                table: "CustomerDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<long>(
                name: "DiscountRate",
                table: "CustomerDiscounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

        }
    }
}
