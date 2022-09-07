using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Netto.Public.DataContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatusCodes",
                columns: table => new
                {
                    Country = table.Column<string>(type: "text", nullable: false),
                    ForIndividuals = table.Column<string>(type: "text", nullable: false),
                    CardsSupport = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatusCodes", x => x.Country);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    BankAddress = table.Column<string>(type: "text", nullable: false),
                    GeoLong = table.Column<double>(type: "double precision", nullable: false),
                    GeoLat = table.Column<double>(type: "double precision", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Accounts_ClientStatusCodes_Country",
                        column: x => x.Country,
                        principalTable: "ClientStatusCodes",
                        principalColumn: "Country",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PassportDatas",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Pandus = table.Column<bool>(type: "boolean", nullable: false),
                    ExoticExchange = table.Column<bool>(type: "boolean", nullable: false),
                    Consultation = table.Column<bool>(type: "boolean", nullable: false),
                    Insurance = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportDatas", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_PassportDatas_Accounts_BankId",
                        column: x => x.BankId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Transfer = table.Column<bool>(type: "boolean", nullable: false),
                    Payments = table.Column<bool>(type: "boolean", nullable: false),
                    TopUp = table.Column<bool>(type: "boolean", nullable: false),
                    CurrencyExchange = table.Column<bool>(type: "boolean", nullable: false),
                    WithdrawCard = table.Column<bool>(type: "boolean", nullable: false),
                    TopUpWithoutCard = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Accounts_BankId",
                        column: x => x.BankId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurities",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weekends = table.Column<bool>(type: "boolean", nullable: false),
                    OpenNow = table.Column<bool>(type: "boolean", nullable: false),
                    AllTime = table.Column<bool>(type: "boolean", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "date", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurities", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_UserSecurities_Accounts_BankId",
                        column: x => x.BankId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Country",
                table: "Accounts",
                column: "Country",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeId",
                table: "Accounts",
                column: "TypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassportDatas");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserSecurities");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientStatusCodes");
        }
    }
}
