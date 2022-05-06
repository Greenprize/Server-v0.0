using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0
{
    public class ReportOrder
    {
        public int ReportOrderId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
