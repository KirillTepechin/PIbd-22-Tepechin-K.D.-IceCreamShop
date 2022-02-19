using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BindingModels
{
    /// <summary>
    /// Мороженое, изготавливаемое в магазине
    /// </summary>
    public class IceCreamBindingModel
    {
        public int? Id { get; set; }
        public string IceCreamName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> IceCreamIngredients { get; set; }

    }
}
