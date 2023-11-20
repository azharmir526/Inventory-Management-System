using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace InventoryManagementSystem.API.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        //public AppDBContext() : base(new DbContextOptionsBuilder<AppDBContext>()
        //.UseSqlServer(new ConfigurationBuilder()
        //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //.AddJsonFile("appsettings.json")
        //.Build()
        //.GetConnectionString("SqlConnection"))
        //.Options)
        //{
        //}

        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Purchases> Purchases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////* One-to-Many Products to Sales
            //modelBuilder.Entity<Sales>()
            //    .HasOne(p => p.Products)
            //    .WithMany(c => c.Sales)
            //    .HasForeignKey(o => o.ProductId);

            ////* One-to-Many Products to Purchases
            //modelBuilder.Entity<Purchases>()
            //    .HasOne(p => p.Products)
            //    .WithMany(c => c.Purchases)
            //    .HasForeignKey(o => o.ProductId);

        }

    }
}
