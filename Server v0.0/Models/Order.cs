using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int ClientID { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ReportOrder> ReportOrders { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
    }
}
