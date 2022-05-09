namespace Server_v0._0.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;

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
            modelBuilder.Entity<Order>()
                        .HasOne(p => p.Status)
                        .WithMany(p => p.Orders);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            List<StreamReader> procedures = new List<StreamReader>();
            List<StreamReader> triggers = new List<StreamReader>();
            procedures.Add(new StreamReader(@"Procedures/Procedure_change_price.txt"));
            procedures.Add(new StreamReader(@"Procedures/Procedure_all_delete.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_create_report.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_discount_when_buying_3_computers.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_ins_upd.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_del.txt"));
            
            foreach (StreamReader reader in procedures)
            {
                try
                {
                    Database.ExecuteSqlCommand(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
            }
            foreach (StreamReader reader in triggers)
            {
                try
                {
                    Database.ExecuteSqlCommand(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
            }
        }
    }
}