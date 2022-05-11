using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Computer name must not exceed 30 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "CPU name must not exceed 80 characters")]
        public string CPU { get; set; }
        [StringLength(80, ErrorMessage = "Video card name must not exceed 80 characters")]
        public string GraphicsCard { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "RAM name must not exceed 80 characters")]
        public string RAM { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "The name of the motherboard must not exceed 80 characters")]
        public string Motherboard { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "The name of the power supply must not exceed 80 characters")]
        public string PowerSupply { get; set; }
        [StringLength(80, ErrorMessage = "The name of the hard drive must not exceed 80 characters")]
        public string HardDrive { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "SSD drive name must not exceed 80 characters")]
        public string SSD_Disk { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Corpus name must not exceed 80 characters")]
        public string Body { get; set; }
        [Required]
        [Range(0, 1000000000, ErrorMessage = "The price cannot be negative")]
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
    }
}
