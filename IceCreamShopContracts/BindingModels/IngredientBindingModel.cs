using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BindingModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления мороженого
    /// </summary>
    public class IngredientBindingModel
    {
        public int? Id { get; set; }
        public string IngredientName { get; set; }
    }
}
