using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public ExcelSheetType SheetType { get; set; }
        public List<ReportIceCreamIngredientViewModel> IceCreamIngredients { get; set; }
        public List<ReportWarhouseIngredientViewModel> WarhouseIngredients { get; set; }

    }
}
