using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class ComputerOrderConfiguration : IEntityTypeConfiguration<ComputerOrder>
    {
        public void Configure(EntityTypeBuilder<ComputerOrder> builder)
        {
            builder.HasKey(s => new { s.OrderId, s.ComputerId });

            builder.HasOne(ss => ss.Order)
                .WithMany(s => s.ComputerOrders)
                .HasForeignKey(ss => ss.OrderId);

            builder.HasOne(ss => ss.Computer)
                .WithMany(s => s.ComputerOrders)
                .HasForeignKey(ss => ss.ComputerId);
        }
    }
}
