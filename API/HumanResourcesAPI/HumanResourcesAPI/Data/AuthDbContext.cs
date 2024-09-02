using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesAPI.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rol Id'leri
            var adminRoleId = "329385b0-2db1-40b0-9dd5-c1323828e2c6";
            var employeeRoleId = "48594e9a-fb94-418d-a277-f208263ce7ee";

            // Admin ve Employee rolleri oluşturma
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Id = employeeRoleId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = employeeRoleId
                }
            };

            // Rolleri veritabanına ekleme
            builder.Entity<IdentityRole>().HasData(roles);

            // Admin kullanıcısı oluşturma
            var adminUserId = "dac02bc4-3eaf-4370-87f1-7a42bb58340a";
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@humanapp.com",
                Email = "admin@humanapp.com",
                NormalizedEmail = "ADMIN@HUMANAPP.COM",
                NormalizedUserName = "ADMIN@HUMANAPP.COM",
                EmailConfirmed = true // E-posta doğrulandı olarak işaretlendi
            };

            // Şifreyi hashleyip admin kullanıcısına atama
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "admin.123");

            // Admin kullanıcısını veritabanına ekleme
            builder.Entity<IdentityUser>().HasData(admin);

            // Admin kullanıcısına rol atama
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = employeeRoleId
                }
            };

            // Rol atamalarını veritabanına ekleme
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
