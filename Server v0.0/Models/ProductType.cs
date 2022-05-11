using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        [Required]
        [StringLength(10)]
        public string Type { get; set; }
        public List<Product> Products { get; set; }
    }
}
