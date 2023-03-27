using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Infrastructure.Persistence.Sql.Migrations
{
    public partial class addfildtoproductttbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValueSql: "10");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValueSql: "100000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");
        }
    }
}
