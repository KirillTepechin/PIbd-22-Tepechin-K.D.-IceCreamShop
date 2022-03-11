using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopDatabaseImplement.Models
{
    public class WarehouseIngredient
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
