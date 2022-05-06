using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server_v0._0.Models
{
    public class ReportOrderConfiguration : IEntityTypeConfiguration<ReportOrder>
    {
        public void Configure(EntityTypeBuilder<ReportOrder> builder)
        {
            builder.HasKey(s => new {s.ReportOrderId});

            builder.HasOne(ss => ss.Order)
                .WithMany(s => s.ReportOrders)
                .HasForeignKey(ss => ss.OrderId);

            builder.HasOne(ss => ss.Report)
                .WithMany(s => s.ReportOrders)
                .HasForeignKey(ss => ss.ReportId);
        }
    }
}
