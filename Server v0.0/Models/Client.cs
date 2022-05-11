using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(40, ErrorMessage = "Email must not exceed 40 characters")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Invalid phone number", MinimumLength = 11)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
