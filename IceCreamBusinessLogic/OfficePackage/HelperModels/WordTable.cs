using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordTable
    {
        public string Header { get; set; }
        public List<WarehouseViewModel> Rows { get; set; }
        public WordTableProperties TableProperties { get; set; }
    }
}
