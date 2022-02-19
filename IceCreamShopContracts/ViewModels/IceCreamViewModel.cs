using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.ViewModels
{
    /// <summary>
    /// Мороженое, изготавливаемое в магазине
    /// </summary>
    public class IceCreamViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название мороженого")]
        public string IceCreamName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> IceCreamIngredients { get; set; }

    }
}
