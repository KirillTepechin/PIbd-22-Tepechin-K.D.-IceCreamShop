using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// </summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient();
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        List<ReportOrdersInfoViewModel> GetOrdersGroupByDate();
        void SaveIceCreamsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveIceCreamIngredientToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
        void SaveOrdersInfoToPdfFile(ReportBindingModel model);
        List<ReportWarhouseIngredientViewModel> GetWarhouseIngredient();
        void SaveWarehousesToWordFile(ReportBindingModel model);
        void SaveWarhouseIngredientToExcelFile(ReportBindingModel model);
    }
}
