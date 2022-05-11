using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Title name must not exceed 20 characters")]
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
