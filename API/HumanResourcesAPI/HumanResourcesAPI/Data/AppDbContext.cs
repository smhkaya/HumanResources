using HumanResourcesAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee modelindeki Salary özelliği için hassasiyet ve ölçek ayarı
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)"); // veya .HasPrecision(18, 2)

            // Diğer model ayarlarını buraya ekleyebilirsiniz

            base.OnModelCreating(modelBuilder);
        }
    }
}
