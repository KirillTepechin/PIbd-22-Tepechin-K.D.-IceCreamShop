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
        public List<WarehouseViewModel> Texts { get; set; }
        public WordTextProperties TextProperties { get; set; }
    }
}
