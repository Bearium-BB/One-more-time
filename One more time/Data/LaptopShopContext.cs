using Microsoft.EntityFrameworkCore;
using One_more_time.Models.Table;
using System.Collections.Generic;
using System.Diagnostics;

namespace One_more_time.Data
{
    public partial class LaptopShopContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Bands { get; set; } = null!;
        public LaptopShopContext(DbContextOptions<LaptopShopContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LaptopShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Laptops)
                .WithOne(l => l.Brand)
                .IsRequired();
        }

    }
}
