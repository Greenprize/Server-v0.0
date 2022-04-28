using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public ICollection<ReportOrder> ReportOrders { get; set; }
    }
}
