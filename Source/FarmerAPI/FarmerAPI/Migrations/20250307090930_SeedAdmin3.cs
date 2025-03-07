using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0b855c86-df54-4374-881f-8f2f040f7c9c", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "b41ff90d-c06d-4397-a639-10e857c4c620", 0, "14ba0011-4127-4945-8d34-aa26655bfb95", new DateTime(2025, 3, 7, 9, 9, 30, 415, DateTimeKind.Utc).AddTicks(966), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFLEpSdsmPiETU+DqanIErhFXHr/YkPllIn6GYxY0RIjFB4+gBXDcs0DA6a0VgI20w==", null, false, null, null, "Admin", "32744bd8-2e53-4421-9400-be8100580eed", false, new DateTime(2025, 3, 7, 9, 9, 30, 415, DateTimeKind.Utc).AddTicks(969), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b855c86-df54-4374-881f-8f2f040f7c9c", "b41ff90d-c06d-4397-a639-10e857c4c620" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b855c86-df54-4374-881f-8f2f040f7c9c", "b41ff90d-c06d-4397-a639-10e857c4c620" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b855c86-df54-4374-881f-8f2f040f7c9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b41ff90d-c06d-4397-a639-10e857c4c620");

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
    }
}
