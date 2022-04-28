using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string Title { get; set; }
        public string CPU { get; set; }
        public string GraphicsCard { get; set; }
        public string RAM { get; set; }
        public string Motherboars { get; set; }
        public string PowerSupply { get; set; }
        public string HardDrive { get; set; }
        public string SSD_Disk { get; set; }
        public string Body { get; set; }
        public string Price { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
    }
}
