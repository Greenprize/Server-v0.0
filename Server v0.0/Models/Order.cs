using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Range(0, 1000000000, ErrorMessage = "The price cannot be negative")]
        public double Price { get; set; }
        [Required]
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ReportOrder> ReportOrders { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
    }
}
