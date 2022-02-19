using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        [DisplayName("Ответственное лицо")]
        public string ResponsiblePerson { get; set; }
        [DisplayName("Дата создания склада")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Ингредиенты")]
        public Dictionary<int, (string, int)> WarehouseIngredients { get; set; }
    }
}
