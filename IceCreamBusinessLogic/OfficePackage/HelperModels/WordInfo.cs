using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IceCreamViewModel> IceCreams { get; set; }
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
