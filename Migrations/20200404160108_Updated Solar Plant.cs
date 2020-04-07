using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VoltairePower.Migrations
{
    public partial class UpdatedSolarPlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(maxLength: 22, nullable: false),
                    Mobile = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UnitNumber = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(maxLength: 11, nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    ConfirmPassword = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsCompletedReg = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolarSheetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolarSize = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    NumberofInverters = table.Column<int>(nullable: false),
                    InverterMakes = table.Column<int>(nullable: false),
                    InverterModel = table.Column<int>(nullable: false),
                    InverterSize = table.Column<int>(nullable: false),
                    NumberOfSolarStrings = table.Column<int>(nullable: false),
                    SolarStringsolarConnection = table.Column<int>(nullable: false),
                    SolarStringsolarModel = table.Column<string>(nullable: true),
                    NumberOfWatts = table.Column<int>(nullable: false),
                    Vmpp = table.Column<int>(nullable: false),
                    Voc = table.Column<int>(nullable: false),
                    Impp = table.Column<int>(nullable: false),
                    Isc = table.Column<int>(nullable: false),
                    TemCoeffoicient = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSheetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSheetDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_CustomerId",
                table: "Logins",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSheetDetails_CustomerId",
                table: "SolarSheetDetails",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "SolarSheetDetails");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
