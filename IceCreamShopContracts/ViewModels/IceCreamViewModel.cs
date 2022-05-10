using IceCreamShopContracts.Attributes;
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
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название мороженого", width: 150)]
        public string IceCreamName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [Column(title: "Ингредиенты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> IceCreamIngredients { get; set; }
        public string GetIngredients()
        {
            string stringIngredients = string.Empty;
            if (IceCreamIngredients != null)
            {
                foreach (var ingr in IceCreamIngredients)
                {
                    stringIngredients += ingr.Key + ") " + ingr.Value.Item1 + ": " + ingr.Value.Item2 + ", ";
                }
            }
            return stringIngredients;
        }
    }
}
