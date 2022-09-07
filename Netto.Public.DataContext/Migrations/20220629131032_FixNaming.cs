using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weekends",
                table: "WorkingHours",
                newName: "IsOpenNow");

            migrationBuilder.RenameColumn(
                name: "OpenNow",
                table: "WorkingHours",
                newName: "IsAllTime");

            migrationBuilder.RenameColumn(
                name: "AllTime",
                table: "WorkingHours",
                newName: "HasWeekends");

            migrationBuilder.RenameColumn(
                name: "WithdrawCard",
                table: "Popular",
                newName: "HasWithdrawCard");

            migrationBuilder.RenameColumn(
                name: "Transfer",
                table: "Popular",
                newName: "HasTransfer");

            migrationBuilder.RenameColumn(
                name: "TopUpWithoutCard",
                table: "Popular",
                newName: "HasTopUpWithoutCard");

            migrationBuilder.RenameColumn(
                name: "TopUp",
                table: "Popular",
                newName: "HasTopUp");

            migrationBuilder.RenameColumn(
                name: "Payments",
                table: "Popular",
                newName: "HasPayments");

            migrationBuilder.RenameColumn(
                name: "CurrencyExchange",
                table: "Popular",
                newName: "HasCurrencyExchange");

            migrationBuilder.RenameColumn(
                name: "Pandus",
                table: "Extras",
                newName: "HasPandus");

            migrationBuilder.RenameColumn(
                name: "Insurance",
                table: "Extras",
                newName: "HasInsurance");

            migrationBuilder.RenameColumn(
                name: "ExoticExchange",
                table: "Extras",
                newName: "HasExoticExchange");

            migrationBuilder.RenameColumn(
                name: "Consultation",
                table: "Extras",
                newName: "HasConsultation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOpenNow",
                table: "WorkingHours",
                newName: "Weekends");

            migrationBuilder.RenameColumn(
                name: "IsAllTime",
                table: "WorkingHours",
                newName: "OpenNow");

            migrationBuilder.RenameColumn(
                name: "HasWeekends",
                table: "WorkingHours",
                newName: "AllTime");

            migrationBuilder.RenameColumn(
                name: "HasWithdrawCard",
                table: "Popular",
                newName: "WithdrawCard");

            migrationBuilder.RenameColumn(
                name: "HasTransfer",
                table: "Popular",
                newName: "Transfer");

            migrationBuilder.RenameColumn(
                name: "HasTopUpWithoutCard",
                table: "Popular",
                newName: "TopUpWithoutCard");

            migrationBuilder.RenameColumn(
                name: "HasTopUp",
                table: "Popular",
                newName: "TopUp");

            migrationBuilder.RenameColumn(
                name: "HasPayments",
                table: "Popular",
                newName: "Payments");

            migrationBuilder.RenameColumn(
                name: "HasCurrencyExchange",
                table: "Popular",
                newName: "CurrencyExchange");

            migrationBuilder.RenameColumn(
                name: "HasPandus",
                table: "Extras",
                newName: "Pandus");

            migrationBuilder.RenameColumn(
                name: "HasInsurance",
                table: "Extras",
                newName: "Insurance");

            migrationBuilder.RenameColumn(
                name: "HasExoticExchange",
                table: "Extras",
                newName: "ExoticExchange");

            migrationBuilder.RenameColumn(
                name: "HasConsultation",
                table: "Extras",
                newName: "Consultation");
        }
    }
}
