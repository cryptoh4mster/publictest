using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class NumberintoBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankAddress",
                table: "Bank",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Bank",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Bank");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Bank",
                newName: "BankAddress");
        }
    }
}
