using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class OnetoMnaybankbankType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bank_TypeId",
                table: "Bank");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_TypeId",
                table: "Bank",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bank_TypeId",
                table: "Bank");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_TypeId",
                table: "Bank",
                column: "TypeId",
                unique: true);
        }
    }
}
