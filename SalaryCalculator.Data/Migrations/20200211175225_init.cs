using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalaryCalculator.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<Guid>(nullable: false),
                    PersonEmail = table.Column<string>(nullable: true),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pensions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HealthSecurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unemployment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Supplementary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Common = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonalIncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93ad4deb-b9f7-4a98-9585-8b79963aee55", "7481bc32-f2a0-45bc-9c10-dcf8cb013679", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e05be19e-09ef-428c-9bcc-cf5ebdf7c56e", 0, "7aa48459-130d-439e-a56b-1b18b67d4941", "admin@admin.com", false, true, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFXn9U+2NxO1IdZLG2eNG4sLx6P0uWGmv6tef5i5DNZw+dBepPK+Q1BmCTazpfwZQQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e05be19e-09ef-428c-9bcc-cf5ebdf7c56e", "93ad4deb-b9f7-4a98-9585-8b79963aee55" });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e05be19e-09ef-428c-9bcc-cf5ebdf7c56e", "93ad4deb-b9f7-4a98-9585-8b79963aee55" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ad4deb-b9f7-4a98-9585-8b79963aee55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e05be19e-09ef-428c-9bcc-cf5ebdf7c56e");
        }
    }
}
