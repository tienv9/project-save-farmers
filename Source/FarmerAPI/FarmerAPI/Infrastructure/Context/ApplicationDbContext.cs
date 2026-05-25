using FarmerAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmerAPI.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///admin user login here
            string LEmail = "admin@admin.com";
            string LPassword = "Admin@123";


            const string adminRoleId = "1";
            const string adminUserId = "1";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<User>();
            var adminUser = new User
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = LEmail,
                NormalizedEmail = LEmail.ToUpper(),
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator",
                Role = "Admin",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, LPassword);

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });

            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Fresh Wheat - Bulk Sale", Price = "15", CropType = "Wheat", Amount = "500", Location = "Spokane, WA", Contact = "5091112233", Description = "High-quality hard red winter wheat, perfect for milling or animal feed.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "farmer1@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0001-0001-0001-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Sweet Corn - Fresh Harvest", Price = "8", CropType = "Corn", Amount = "300", Location = "Yakima, WA", Contact = "5092223344", Description = "Freshly harvested sweet corn, available for pickup or local delivery.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "grower2@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0002-0002-0002-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Organic Honeycrisp Apples", Price = "25", CropType = "Apples", Amount = "200", Location = "Wenatchee, WA", Contact = "5093334455", Description = "Certified organic Honeycrisp apples. Great for direct retail or farmers markets.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "orchard3@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0003-0003-0003-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("44444444-4444-4444-4444-444444444444"), Title = "Russet Potatoes - 50lb Bags", Price = "20", CropType = "Potatoes", Amount = "150", Location = "Moses Lake, WA", Contact = "5094445566", Description = "Idaho-style russet potatoes grown in Eastern Washington. Sold in 50lb bags.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "potato4@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0004-0004-0004-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("55555555-5555-5555-5555-555555555555"), Title = "Roma Tomatoes - Wholesale", Price = "12", CropType = "Tomatoes", Amount = "400", Location = "Tri-Cities, WA", Contact = "5095556677", Description = "Firm Roma tomatoes ideal for sauces and canning. Wholesale pricing available.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "veggie5@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0005-0005-0005-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("66666666-6666-6666-6666-666666666666"), Title = "Non-GMO Soybeans", Price = "18", CropType = "Soybeans", Amount = "600", Location = "Pullman, WA", Contact = "5096667788", Description = "Certified non-GMO soybeans. Suitable for food-grade and feed markets.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "crops6@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0006-0006-0006-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("77777777-7777-7777-7777-777777777777"), Title = "Fresh Strawberries - Pick Up Only", Price = "30", CropType = "Strawberries", Amount = "100", Location = "Bellingham, WA", Contact = "5097778899", Description = "Vine-ripened strawberries. Pick-up only at the farm. Call ahead to schedule.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "berry7@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0007-0007-0007-aaaaaaaaaaaa") },
                new Post { PostId = new Guid("88888888-8888-8888-8888-888888888888"), Title = "Baby Carrots - Restaurant Supply", Price = "10", CropType = "Carrots", Amount = "250", Location = "Olympia, WA", Contact = "5098889900", Description = "Pre-washed baby carrots ready for restaurant and grocery supply chains.", CreateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), UpdateDate = new DateTime(2026, 5, 25, 0, 0, 0, DateTimeKind.Utc), ExpireDate = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc), Name = "garden8@example.com", Status = "Active", UserId = new Guid("aaaaaaaa-0008-0008-0008-aaaaaaaaaaaa") }
            );
        }
    }
}