using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [StringLength(10)]
        public string TitleP { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
