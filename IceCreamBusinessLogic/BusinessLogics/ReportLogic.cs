using IceCreamShopBusinessLogic.OfficePackage;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IIngredientStorage _ingredientStorage;
        private readonly IIceCreamStorage _iceCreamStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IIceCreamStorage iceCreamStorage, IIngredientStorage
       ingredientStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
       AbstractSaveToPdf saveToPdf)
        {
            _iceCreamStorage = iceCreamStorage;
            _ingredientStorage = ingredientStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>/// <returns></returns>
        public List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient()
        {
            var iceCreams = _iceCreamStorage.GetFullList();
            var list = new List<ReportIceCreamIngredientViewModel>();
            foreach (var ic in iceCreams)
            {
                var record = new ReportIceCreamIngredientViewModel
                {
                    IceCreamName = ic.IceCreamName,
                    Ingredients = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var ingr in ic.IceCreamIngredients)
                {
                    record.Ingredients.Add(new Tuple<string, int>(ingr.Value.Item1, ingr.Value.Item2));
                    record.TotalCount += ingr.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                IceCreamName = x.IceCreamName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveIceCreamsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список мороженого",
                IceCreams = _iceCreamStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveIceCreamIngredientToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список мороженого",
                IceCreamIngredients = GetIceCreamIngredient()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDocWarehouse(new WordInfo
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }
    }
}
