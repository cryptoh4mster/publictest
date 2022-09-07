using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class ContactPhonesOnetomanytobank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bank_Country",
                table: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_Bank_TypeId",
                table: "Bank");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Country",
                table: "Bank",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_TypeId",
                table: "Bank",
                column: "TypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bank_Country",
                table: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_Bank_TypeId",
                table: "Bank");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Country",
                table: "Bank",
                column: "Country",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bank_TypeId",
                table: "Bank",
                column: "TypeId");
        }
    }
}
