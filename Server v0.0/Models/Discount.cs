using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        [Required]
        public string AmountOfDiscount { get; set; }
        [StringLength(20)]
        public string DiscountType { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
