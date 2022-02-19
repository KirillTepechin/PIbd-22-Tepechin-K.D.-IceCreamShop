using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarhouseIngredients { get; set; }
    }
}
