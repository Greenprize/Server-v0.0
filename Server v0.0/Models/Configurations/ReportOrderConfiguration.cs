using Microsoft.EntityFrameworkCore;
namespace Server_v0._0.Models
{
    public class ReportOrderConfiguration : IEntityTypeConfiguration<ReportOrder>
    {
        public void Configure(IEntityTypeConfiguration<ReportOrder> builder)
        {
            builder.HasKey(s => new { s.ClientId, s.ReportId });

            builder.HasOne(ss => ss.Client)
                .WithMany(s => s.ReportOrder)
                .HasForeignKey(ss => ss.ClientId);

            builder.HasOne(ss => ss.Report)
                .WithMany(s => s.ReportOrder)
                .HasForeignKey(ss => ss.ReportId);
        }
    }
}
