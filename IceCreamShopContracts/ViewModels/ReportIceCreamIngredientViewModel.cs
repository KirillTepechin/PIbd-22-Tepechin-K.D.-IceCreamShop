using IceCreamShopContracts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.ViewModels
{
    public class ReportIceCreamIngredientViewModel
    {
        public string IceCreamName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Ingredients { get; set; }
    }
}
