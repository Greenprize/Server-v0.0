using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        public string FullName { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
