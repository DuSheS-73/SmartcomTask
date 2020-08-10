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

        //public DbSet<ApplicationUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ForeignKeys definition
            //builder.Entity<Order>()
            //    .HasOne<Customer>()
            //    .WithMany()
            //    .HasForeignKey(k => k.CustomerID);

            //builder.Entity<OrderElement>()
            //    .HasOne<Order>()
            //    .WithOne()
            //    .HasForeignKey<OrderElement>(k => k.OrderID);

            //builder.Entity<OrderElement>()
            //    .HasOne<Item>()
            //    .WithOne()
            //    //.HasPrincipalKey<Item>(p => p.ID)
            //    .HasForeignKey<OrderElement>(k => k.ItemID);
            //    //.OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderElement>()
                .HasOne<Item>()
                .WithOne()
                .HasPrincipalKey<Item>(p => p.Price)
                .HasForeignKey<OrderElement>(k => k.ItemPrice)
                .OnDelete(DeleteBehavior.NoAction);



            // Roles definition
            var adminRoleId = Guid.NewGuid();
            var adminId = Guid.NewGuid();

            var userRoleId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            // DEMO Admin role
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
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




            // DEMO User role
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            // DEMO User
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = "Customer",
                NormalizedUserName = "CUSTOMER",
                Email = "customer@email.com",
                NormalizedEmail = "CUSTOMER@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "CustomerPass"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = userRoleId,
                UserId = userId
            });


            // DEMO Customer
            //var tempId = Guid.NewGuid();



            // DEMO Order
            //var demoOrder = new Order
            //{
            //    ID = Guid.NewGuid(),
            //    CustomerID = tempId,
            //    OrderDate = DateTime.Now
            //};
            //var demoItem = new Item
            //{
            //    ID = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
            //    Code = "11-1111-AB11",
            //    Name = "Shampoo",
            //    Price = 179,
            //    Category = "For bathroom"
            //};



            //builder.Entity<Order>().HasData(demoOrder);

            //// DEMO OrderElement
            //builder.Entity<OrderElement>().HasData(new OrderElement
            //{
            //    ID = Guid.NewGuid(),
            //    OrderID = demoOrder.ID,
            //    ItemID = demoItem.ID,
            //    ItemsCount = 3,
            //    ItemPrice = demoItem.Price
            //});

            //builder.Entity<Item>().HasData(demoItem);


            //// DEMO Items
            //builder.Entity<Item>().HasData(new Item
            //{
            //    ID = Guid.NewGuid(),
            //    Code = "22-2222-CD22",
            //    Name = "Fork",
            //    Price = 99,
            //    Category = "For kitchen"
            //});

            //builder.Entity<Item>().HasData(new Item
            //{
            //    ID = Guid.NewGuid(),
            //    Code = "33-3333-EF33",
            //    Name = "Pillow",
            //    Price = 499,
            //    Category = "For bedroom"
            //});
        }
    }
}
