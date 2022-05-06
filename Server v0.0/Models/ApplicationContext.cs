namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportOrder> ReportOrders { get; set; }
        public DbSet<ComputerOrder> ComputerOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportOrderConfiguration());
            modelBuilder.ApplyConfiguration(new ComputerOrderConfiguration());
            modelBuilder.Entity<Order>()
                        .HasOne(p => p.Client)
                        .WithMany(p => p.Orders);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}