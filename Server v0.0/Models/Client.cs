using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
