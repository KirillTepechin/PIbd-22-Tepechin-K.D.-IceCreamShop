using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BindingModels
{
    public class ReplenishBindingModel
    {
        public int WarehouseId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
