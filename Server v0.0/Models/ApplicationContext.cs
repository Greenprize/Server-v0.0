using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;
namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductType> Clients { get; set; }
        public DbSet<Product> Orders { get; set; }
        public DbSet<Material> Computers { get; set; }
        public DbSet<ProductMaterial> ComputerOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComputerOrderConfiguration());
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.ProductType)
                        .WithMany(p => p.Products);
            modelBuilder.Entity<Sale>()
                        .HasOne(p => p.Product)
                        .WithMany(p => p.Sales);
            modelBuilder.Entity<Sale>()
                        .HasOne(p => p.Customer)
                        .WithMany(p => p.Sales);
            modelBuilder.Entity<Customer>()
                        .HasOne(p => p.Discount)
                        .WithMany(p => p.Customers);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Server_v0._0.Models.Discount> Discount { get; set; }
        public DbSet<Server_v0._0.Models.Customer> Customer { get; set; }
        public DbSet<Server_v0._0.Models.Sale> Sale { get; set; }
    }
}