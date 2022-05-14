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
    /// Ингредиент, требуемый для изготовления мороженого
    /// </summary>
    public class IngredientViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название ингредиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string IngredientName { get; set; }
    }
}
