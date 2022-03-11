using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamShopDatabaseImplement.Models
{
    public class IceCream
    {
        public int Id { get; set; }
        [Required]
        public string IceCreamName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<IceCreamIngredient> IceCreamIngredients { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<Order> Orders { get; set; }
    }
}
