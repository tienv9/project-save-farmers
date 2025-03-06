using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3089d4ae-271a-4e7a-ba81-03bff129e47c", "05b83e24-e6bc-4213-9891-46881d3dee56" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3089d4ae-271a-4e7a-ba81-03bff129e47c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05b83e24-e6bc-4213-9891-46881d3dee56");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80813386-582e-43bc-9a04-f9769b7b0da4", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "f21afcff-26a4-489e-b924-fa57c93d6524", 0, "1e4adbb9-ab4b-486a-85f6-74f5b1d9ad5b", new DateTime(2025, 3, 5, 21, 33, 48, 631, DateTimeKind.Utc).AddTicks(887), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEECjd3ybuSSB6GcXz/8J0kYOkokiV0C9/g14Fhg0T0xFtLj9BS2cw7QwH+r2KMWs1g==", null, false, null, null, "Admin", "d0623744-e0ba-40bb-bcf8-51a18781e09a", false, new DateTime(2025, 3, 5, 21, 33, 48, 631, DateTimeKind.Utc).AddTicks(890), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "80813386-582e-43bc-9a04-f9769b7b0da4", "f21afcff-26a4-489e-b924-fa57c93d6524" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80813386-582e-43bc-9a04-f9769b7b0da4", "f21afcff-26a4-489e-b924-fa57c93d6524" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80813386-582e-43bc-9a04-f9769b7b0da4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f21afcff-26a4-489e-b924-fa57c93d6524");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3089d4ae-271a-4e7a-ba81-03bff129e47c", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "05b83e24-e6bc-4213-9891-46881d3dee56", 0, "f9bb6c9c-6b93-4453-a472-8d2acd326d92", new DateTime(2025, 3, 5, 3, 14, 5, 223, DateTimeKind.Utc).AddTicks(2612), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEKtbTzdUtxONbpplE834CgLCFMRBeiIIea77nTOEux1v9YTczhsKpZIS4TjXFMx8EQ==", null, false, null, null, "Admin", "94bcdb0b-1772-4e65-8218-5fa1933c0f6d", false, new DateTime(2025, 3, 5, 3, 14, 5, 223, DateTimeKind.Utc).AddTicks(2614), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3089d4ae-271a-4e7a-ba81-03bff129e47c", "05b83e24-e6bc-4213-9891-46881d3dee56" });
        }
    }
}
