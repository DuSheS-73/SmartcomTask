using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartcomTask.Models;

namespace SmartcomTask.Domain
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrdersElements { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ForeignKeys definition
            builder.Entity<Customer>()
                .HasOne<ApplicationUser>()
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(k => k.CustomerId);

            // To create dependency
            var adminRoleId = Guid.NewGuid();
            var adminId = Guid.NewGuid();

            // Add 2 roles by default: "Admin" & "User"
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = Guid.NewGuid(),
                Name = "User",
                NormalizedName = "USER"
            });

            // DEMO Admin
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "SuperPassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });
        }
    }
}
