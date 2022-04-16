using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            decimal sum = 0;
            if (info.Type == PdfReportType.Filtered)
            {
                CreateParagraph(new PdfParagraph
                {
                    Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }",
                    Style = "Normal"
                });
                CreateTable(new List<string> { "3cm", "6cm", "3cm", "2cm", "3cm" });
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { "Дата заказа", "Изделие", "Количество",
"Сумма", "Статус" },
                    Style = "NormalTitle",
                    ParagraphAlignment = PdfParagraphAlignmentType.Center
                });
                foreach (var order in info.Orders)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Texts = new List<string> { order.DateCreate.ToShortDateString(),
order.IceCreamName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString()
},
                        Style = "Normal",
                        ParagraphAlignment = PdfParagraphAlignmentType.Left
                    });
                }
                sum = info.Orders.Sum(order => order.Sum);
            }
            else
            {  
                CreateTable(new List<string> { "3cm", "3cm", "2cm" });
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { "Дата заказа", "Количество", "Сумма" },
                    Style = "NormalTitle",
                    ParagraphAlignment = PdfParagraphAlignmentType.Center
                });
                foreach (var order in info.OrdersInfo)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Texts = new List<string> { order.DateCreate.ToShortDateString(),
 order.Count.ToString(), order.Sum.ToString()
},
                        Style = "Normal",
                        ParagraphAlignment = PdfParagraphAlignmentType.Left
                    });
                }
                sum = info.OrdersInfo.Sum(order => order.Sum);
            }
            
            CreateParagraph(new PdfParagraph
            {
                Text = $"Итого: { sum }",
                Style = "Normal"
            });
            SavePdf(info);
        }
        /// <summary>/// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreatePdf(PdfInfo info);
        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);
        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SavePdf(PdfInfo info);
    }
}
