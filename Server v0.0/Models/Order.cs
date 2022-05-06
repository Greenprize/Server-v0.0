using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Price { get; set; }
        public ICollection<ReportOrder> ReportOrders { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
