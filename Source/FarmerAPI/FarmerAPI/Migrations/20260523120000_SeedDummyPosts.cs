using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Title", "Price", "CropType", "Amount", "Location", "Contact", "Description", "CreateDate", "UpdateDate", "ExpireDate", "Name", "Status", "UserId" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Fresh Wheat - Bulk Sale",
                        "15",
                        "Wheat",
                        "500",
                        "Spokane, WA",
                        "5091112233",
                        "High-quality hard red winter wheat, perfect for milling or animal feed.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "farmer1@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0001-0001-0001-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Sweet Corn - Fresh Harvest",
                        "8",
                        "Corn",
                        "300",
                        "Yakima, WA",
                        "5092223344",
                        "Freshly harvested sweet corn, available for pickup or local delivery.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "grower2@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0002-0002-0002-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Organic Honeycrisp Apples",
                        "25",
                        "Apples",
                        "200",
                        "Wenatchee, WA",
                        "5093334455",
                        "Certified organic Honeycrisp apples. Great for direct retail or farmers markets.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "orchard3@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0003-0003-0003-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Russet Potatoes - 50lb Bags",
                        "20",
                        "Potatoes",
                        "150",
                        "Moses Lake, WA",
                        "5094445566",
                        "Idaho-style russet potatoes grown in Eastern Washington. Sold in 50lb bags.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "potato4@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0004-0004-0004-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Roma Tomatoes - Wholesale",
                        "12",
                        "Tomatoes",
                        "400",
                        "Tri-Cities, WA",
                        "5095556677",
                        "Firm Roma tomatoes ideal for sauces and canning. Wholesale pricing available.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "veggie5@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0005-0005-0005-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Non-GMO Soybeans",
                        "18",
                        "Soybeans",
                        "600",
                        "Pullman, WA",
                        "5096667788",
                        "Certified non-GMO soybeans. Suitable for food-grade and feed markets.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "crops6@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0006-0006-0006-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Fresh Strawberries - Pick Up Only",
                        "30",
                        "Strawberries",
                        "100",
                        "Bellingham, WA",
                        "5097778899",
                        "Vine-ripened strawberries. Pick-up only at the farm. Call ahead to schedule.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "berry7@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0007-0007-0007-aaaaaaaaaaaa")
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "Baby Carrots - Restaurant Supply",
                        "10",
                        "Carrots",
                        "250",
                        "Olympia, WA",
                        "5098889900",
                        "Pre-washed baby carrots ready for restaurant and grocery supply chains.",
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(2026, 5, 23, 12, 0, 0, DateTimeKind.Utc),
                        new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                        "garden8@example.com",
                        "Active",
                        new Guid("aaaaaaaa-0008-0008-0008-aaaaaaaaaaaa")
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValues: new object[]
                {
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    new Guid("44444444-4444-4444-4444-444444444444"),
                    new Guid("55555555-5555-5555-5555-555555555555"),
                    new Guid("66666666-6666-6666-6666-666666666666"),
                    new Guid("77777777-7777-7777-7777-777777777777"),
                    new Guid("88888888-8888-8888-8888-888888888888")
                });
        }
    }
}
