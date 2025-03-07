using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8ff81eff-3b0d-4301-aa88-011ec397e3a3", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "1629169b-055e-4355-8e32-1d518ef6e59d", 0, "33157981-d0d5-4a5b-bb79-4138e358d8f6", new DateTime(2025, 3, 7, 3, 42, 52, 262, DateTimeKind.Utc).AddTicks(3714), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEMzLuSHZTwcs55FuJyvFFtQjXhqisiroMleutmJGBppQx3C0kyZ+d0y9MjGl+3C0Dw==", null, false, null, null, "Admin", "5eeeeeeb-9ce4-4c53-8d1b-7bf363440adc", false, new DateTime(2025, 3, 7, 3, 42, 52, 262, DateTimeKind.Utc).AddTicks(3715), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8ff81eff-3b0d-4301-aa88-011ec397e3a3", "1629169b-055e-4355-8e32-1d518ef6e59d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8ff81eff-3b0d-4301-aa88-011ec397e3a3", "1629169b-055e-4355-8e32-1d518ef6e59d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff81eff-3b0d-4301-aa88-011ec397e3a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1629169b-055e-4355-8e32-1d518ef6e59d");

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
    }
}
