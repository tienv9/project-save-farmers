using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    CropType = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { "1", 0, "4ae173ee-436c-4aa1-bb8a-30fa0f2e1847", new DateTime(2026, 5, 25, 23, 6, 33, 758, DateTimeKind.Utc).AddTicks(8333), "admin@admin.com", true, "System", "Administrator", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEBOh9VDIsWRjKXEn6TmrMlrCPIGqL6m64pzc50apkGYYdhvGCvLeB+bvIv5Zjpg4nQ==", null, false, null, null, "Admin", "05f816ee-6050-41d6-9911-fec41f58fdff", false, new DateTime(2026, 5, 25, 23, 6, 33, 758, DateTimeKind.Utc).AddTicks(8334), "admin" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Amount", "Contact", "CreateDate", "CropType", "Description", "ExpireDate", "Location", "Name", "Price", "Status", "Title", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "500", "5091112233", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Wheat", "High-quality hard red winter wheat, perfect for milling or animal feed.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Spokane, WA", "farmer1@example.com", "15", "Active", "Fresh Wheat - Bulk Sale", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0001-0001-0001-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "300", "5092223344", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Corn", "Freshly harvested sweet corn, available for pickup or local delivery.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Yakima, WA", "grower2@example.com", "8", "Active", "Sweet Corn - Fresh Harvest", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0002-0002-0002-aaaaaaaaaaaa") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "200", "5093334455", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Apples", "Certified organic Honeycrisp apples. Great for direct retail or farmers markets.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Wenatchee, WA", "orchard3@example.com", "25", "Active", "Organic Honeycrisp Apples", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0003-0003-0003-aaaaaaaaaaaa") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "150", "5094445566", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Potatoes", "Idaho-style russet potatoes grown in Eastern Washington. Sold in 50lb bags.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Moses Lake, WA", "potato4@example.com", "20", "Active", "Russet Potatoes - 50lb Bags", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0004-0004-0004-aaaaaaaaaaaa") },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "400", "5095556677", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Tomatoes", "Firm Roma tomatoes ideal for sauces and canning. Wholesale pricing available.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Tri-Cities, WA", "veggie5@example.com", "12", "Active", "Roma Tomatoes - Wholesale", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0005-0005-0005-aaaaaaaaaaaa") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "600", "5096667788", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Soybeans", "Certified non-GMO soybeans. Suitable for food-grade and feed markets.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Pullman, WA", "crops6@example.com", "18", "Active", "Non-GMO Soybeans", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0006-0006-0006-aaaaaaaaaaaa") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "100", "5097778899", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Strawberries", "Vine-ripened strawberries. Pick-up only at the farm. Call ahead to schedule.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Bellingham, WA", "berry7@example.com", "30", "Active", "Fresh Strawberries - Pick Up Only", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0007-0007-0007-aaaaaaaaaaaa") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "250", "5098889900", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Carrots", "Pre-washed baby carrots ready for restaurant and grocery supply chains.", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Olympia, WA", "garden8@example.com", "10", "Active", "Baby Carrots - Restaurant Supply", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-0008-0008-0008-aaaaaaaaaaaa") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
