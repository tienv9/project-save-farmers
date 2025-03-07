using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f8073858-d67c-4d0b-9040-fc6cf6cce5d3", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "258f7cb1-199c-49bb-8892-9a98c967c56e", 0, "ec1bea6a-f394-4b54-b2ea-5d6db253be77", new DateTime(2025, 3, 6, 23, 18, 11, 803, DateTimeKind.Utc).AddTicks(883), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEETuY2Oaw/j9b1XJCD7QIX4gvQBDhVppux4ox8kTimb4PQ9KBF+b9PfeNaXxbX0+ag==", null, false, null, null, "Admin", "88c319b0-0030-41a4-a322-bb60cf6bae4a", false, new DateTime(2025, 3, 6, 23, 18, 11, 803, DateTimeKind.Utc).AddTicks(890), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8073858-d67c-4d0b-9040-fc6cf6cce5d3", "258f7cb1-199c-49bb-8892-9a98c967c56e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8073858-d67c-4d0b-9040-fc6cf6cce5d3", "258f7cb1-199c-49bb-8892-9a98c967c56e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8073858-d67c-4d0b-9040-fc6cf6cce5d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "258f7cb1-199c-49bb-8892-9a98c967c56e");

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
    }
}
