using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class ChangeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_TypeId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_ClientStatusCodes_Country",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_PassportDatas_Accounts_BankId",
                table: "PassportDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Accounts_BankId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurities_Accounts_BankId",
                table: "UserSecurities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSecurities",
                table: "UserSecurities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassportDatas",
                table: "PassportDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientStatusCodes",
                table: "ClientStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "UserSecurities",
                newName: "WorkingHours");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "Popular");

            migrationBuilder.RenameTable(
                name: "PassportDatas",
                newName: "Extras");

            migrationBuilder.RenameTable(
                name: "ClientStatusCodes",
                newName: "ContactPhones");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "BankType");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Bank");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_TypeId",
                table: "Bank",
                newName: "IX_Bank_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Country",
                table: "Bank",
                newName: "IX_Bank_Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingHours",
                table: "WorkingHours",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Popular",
                table: "Popular",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Extras",
                table: "Extras",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPhones",
                table: "ContactPhones",
                column: "Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankType",
                table: "BankType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bank",
                table: "Bank",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_BankType_TypeId",
                table: "Bank",
                column: "TypeId",
                principalTable: "BankType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_ContactPhones_Country",
                table: "Bank",
                column: "Country",
                principalTable: "ContactPhones",
                principalColumn: "Country",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Bank_BankId",
                table: "Extras",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Popular_Bank_BankId",
                table: "Popular",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Bank_BankId",
                table: "WorkingHours",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank_BankType_TypeId",
                table: "Bank");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank_ContactPhones_Country",
                table: "Bank");

            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Bank_BankId",
                table: "Extras");

            migrationBuilder.DropForeignKey(
                name: "FK_Popular_Bank_BankId",
                table: "Popular");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Bank_BankId",
                table: "WorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingHours",
                table: "WorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Popular",
                table: "Popular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Extras",
                table: "Extras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPhones",
                table: "ContactPhones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankType",
                table: "BankType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bank",
                table: "Bank");

            migrationBuilder.RenameTable(
                name: "WorkingHours",
                newName: "UserSecurities");

            migrationBuilder.RenameTable(
                name: "Popular",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "Extras",
                newName: "PassportDatas");

            migrationBuilder.RenameTable(
                name: "ContactPhones",
                newName: "ClientStatusCodes");

            migrationBuilder.RenameTable(
                name: "BankType",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Bank",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Bank_TypeId",
                table: "Accounts",
                newName: "IX_Accounts_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bank_Country",
                table: "Accounts",
                newName: "IX_Accounts_Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSecurities",
                table: "UserSecurities",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassportDatas",
                table: "PassportDatas",
                column: "BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientStatusCodes",
                table: "ClientStatusCodes",
                column: "Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_TypeId",
                table: "Accounts",
                column: "TypeId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_ClientStatusCodes_Country",
                table: "Accounts",
                column: "Country",
                principalTable: "ClientStatusCodes",
                principalColumn: "Country",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PassportDatas_Accounts_BankId",
                table: "PassportDatas",
                column: "BankId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Accounts_BankId",
                table: "UserProfiles",
                column: "BankId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurities_Accounts_BankId",
                table: "UserSecurities",
                column: "BankId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
