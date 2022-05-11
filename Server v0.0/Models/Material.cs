using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        [StringLength(20)]
        public string Title_M { get; set; }
        public double PricePerGram { get; set; }
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}
