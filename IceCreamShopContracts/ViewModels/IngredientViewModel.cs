using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.ViewModels
{
    /// <summary>
    /// Ингредиент, требуемый для изготовления мороженого
    /// </summary>
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название ингредиента")]
        public string IngredientName { get; set; }
    }
}
