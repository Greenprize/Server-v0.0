using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0
{
    public class ComputerOrder
    {
        public int ComputerOrderId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int Count { get; set;}
    }
}
