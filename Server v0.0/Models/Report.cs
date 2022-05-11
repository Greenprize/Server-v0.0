using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters")]
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Link must not exceed 100 characters")]
        public string Link { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ReportOrder> ReportOrders { get; set; }
    }
}
