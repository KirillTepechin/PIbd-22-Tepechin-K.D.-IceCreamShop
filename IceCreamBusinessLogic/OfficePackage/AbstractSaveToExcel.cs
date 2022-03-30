﻿using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="info"></param>
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });
            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });
            uint rowIndex = 2;
            if (info.SheetType == ExcelSheetType.IceCream)
            {
                foreach (var ii in info.IceCreamIngredients)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "A",
                        RowIndex = rowIndex,
                        Text = ii.IceCreamName,
                        StyleInfo = ExcelStyleInfoType.Text
                    });
                    rowIndex++;
                    foreach (var iceCream in ii.Ingredients)
                    {
                        InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = "B",
                            RowIndex = rowIndex,
                            Text = iceCream.Item1,
                            StyleInfo = ExcelStyleInfoType.TextWithBroder
                        });
                        InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = "C",
                            RowIndex = rowIndex,
                            Text = iceCream.Item2.ToString(),
                            StyleInfo = ExcelStyleInfoType.TextWithBroder
                        });
                        rowIndex++;
                    }
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = ii.TotalCount.ToString(),
                        StyleInfo = ExcelStyleInfoType.Text
                    });
                    rowIndex++;
                }
            }
            else
            {
                foreach (var wi in info.WarhouseIngredients)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "A",
                        RowIndex = rowIndex,
                        Text = wi.WarhouseName,
                        StyleInfo = ExcelStyleInfoType.Text
                    });
                    rowIndex++;
                    foreach (var ingredient in wi.Ingredients)
                    {
                        InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = "B",
                            RowIndex = rowIndex,
                            Text = ingredient.Item1,
                            StyleInfo = ExcelStyleInfoType.TextWithBroder
                        });
                        InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = "C",
                            RowIndex = rowIndex,
                            Text = ingredient.Item2.ToString(),
                            StyleInfo = ExcelStyleInfoType.TextWithBroder
                        });
                        rowIndex++;
                    }
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = wi.TotalCount.ToString(),
                        StyleInfo = ExcelStyleInfoType.Text
                    });
                    rowIndex++;
                }
            }
            
            SaveExcel(info);
        }
        /// <summary>
        /// Создание excel-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateExcel(ExcelInfo info);
        /// <summary>
        /// Добавляем новую ячейку в лист
        /// </summary>
        /// <param name="cellParameters"></param>
        protected abstract void InsertCellInWorksheet(ExcelCellParameters
        excelParams);
        /// <summary>
        /// Объединение ячеек
        /// </summary>
        /// <param name="mergeParameters"></param>
        protected abstract void MergeCells(ExcelMergeParameters excelParams);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SaveExcel(ExcelInfo info);
    }
}