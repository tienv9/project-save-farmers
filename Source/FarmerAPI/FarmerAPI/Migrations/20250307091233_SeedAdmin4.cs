using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2dc0e929-d7c0-4cd9-a73f-fe71b5b1d04c", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "62270ef0-206d-48fc-8eb5-e05a5b09cf8d", 0, "f333ca7c-00a6-4273-b1b5-e4900cb5aa18", new DateTime(2025, 3, 7, 9, 12, 33, 329, DateTimeKind.Utc).AddTicks(8321), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFJrHqww3/sc87bnqXbsxuPgPlEQo+DHaozAwmfunfjBTJR74EdZk+YgsQaxHpTq8w==", null, false, null, null, "Admin", "085f99dd-7fb7-4c64-a324-b69c7dd630c9", false, new DateTime(2025, 3, 7, 9, 12, 33, 329, DateTimeKind.Utc).AddTicks(8323), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2dc0e929-d7c0-4cd9-a73f-fe71b5b1d04c", "62270ef0-206d-48fc-8eb5-e05a5b09cf8d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2dc0e929-d7c0-4cd9-a73f-fe71b5b1d04c", "62270ef0-206d-48fc-8eb5-e05a5b09cf8d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dc0e929-d7c0-4cd9-a73f-fe71b5b1d04c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62270ef0-206d-48fc-8eb5-e05a5b09cf8d");

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
    }
}
