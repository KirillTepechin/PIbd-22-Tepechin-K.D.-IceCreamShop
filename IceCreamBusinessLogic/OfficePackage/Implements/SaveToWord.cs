using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage.Implements
{
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument _wordDocument;
        private Body _docBody;
        //private Table _docTable;
        /// <summary>
        /// Получение типа выравнивания
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static JustificationValues GetJustificationValues(WordJustificationType
       type)
        {
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }
        /// <summary>
        /// Настройки страницы
        /// </summary>
        /// <returns></returns>
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        /// <summary>
        /// Задание форматирования для абзаца
        /// </summary>
        /// <param name="paragraphProperties"></param>
        /// <returns></returns>
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties
       paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                var properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = GetJustificationValues(paragraphProperties.JustificationType)
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val =
                   paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }
        private static TableProperties CreateTableProperties(WordTextProperties
       tableProperties)
        {
            if (tableProperties != null)
            {
                
                var properties = new TableProperties(
                 new TableBorders(
                     new TopBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = (uint)Convert.ToInt32(tableProperties.Size)
                     },
                     new BottomBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = 6
                     },
                     new LeftBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = 6
                     },
                     new RightBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = 6
                     },
                     new InsideHorizontalBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = 6
                     },
                     new InsideVerticalBorder()
                     {
                         Val =
                         new EnumValue<BorderValues>(BorderValues.Single),
                         Size = 6
                     }
                 )
             );
                return properties;
            }
            return null;
        }
        protected override void CreateWord(WordInfo info)
        {
            _wordDocument = WordprocessingDocument.Create(info.FileName,
           WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            _docBody = mainPart.Document.AppendChild(new Body());
        }
        protected override void CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                var docParagraph = new Paragraph();

                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    var docRun = new Run();
                    var properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space =
                   SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                _docBody.AppendChild(docParagraph);
            }
        }
        protected override void CreateTable(WordTable table)
        {

            if (table != null)
            {
                var docTable = new Table();


                // Append the TableProperties object to the empty table.
                docTable.AppendChild(CreateTableProperties(table.TextProperties));



                foreach (var row in table.Texts)
                {
                    // Create a cell.
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    TableCell tc3 = new TableCell();
                    // Create a row.
                    TableRow tr = new TableRow();
                    // Specify the width property of the table cell.
                    tc1.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc1.Append(new Paragraph(new Run(new Text(row.WarehouseName))));
                    tc2.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc2.Append(new Paragraph(new Run(new Text(row.ResponsiblePerson))));
                    tc3.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc3.Append(new Paragraph(new Run(new Text(row.DateCreate.ToString()))));
                    tr.Append(tc1);
                    tr.Append(tc2);
                    tr.Append(tc3);
                    
                    docTable.Append(tr);
                }
                
                
                _docBody.AppendChild(docTable);
            }
        }
        protected override void SaveWord(WordInfo info)
        {
            _docBody.AppendChild(CreateSectionProperties());
            _wordDocument.MainDocumentPart.Document.Save();
            _wordDocument.Close();
        }

    }
}
