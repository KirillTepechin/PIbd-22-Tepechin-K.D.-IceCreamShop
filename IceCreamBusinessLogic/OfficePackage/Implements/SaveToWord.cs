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
        private static BorderValues GetBorderValues(WordBorderType
       type)
        {
            return type switch
            {
                WordBorderType.Single => BorderValues.Single,
                WordBorderType.Dashed => BorderValues.Dashed,
                _ => BorderValues.Hearts
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
        private static TableProperties CreateTableProperties(WordTableProperties
       tableProperties)
        {
            if (tableProperties != null)
            {
                var properties = new TableProperties(
            
                    new FontSize()
                    {
                        Val = tableProperties.TextSize
                    },

                    new TableBorders(
                        new TopBorder()
                        {
                            Val = GetBorderValues(tableProperties.BorderType),
                            Size = Convert.ToUInt32(tableProperties.BorderSize)
                        },
                        new BottomBorder()
                        {
                             Val = GetBorderValues(tableProperties.BorderType),
                             Size = Convert.ToUInt32(tableProperties.BorderSize)
                        },
                        new LeftBorder()
                        {
                             Val = GetBorderValues(tableProperties.BorderType),
                             Size = Convert.ToUInt32(tableProperties.BorderSize)
                        },
                        new RightBorder()
                        {
                            Val = GetBorderValues(tableProperties.BorderType),
                            Size = Convert.ToUInt32(tableProperties.BorderSize)
                        },
                        new InsideHorizontalBorder()
                        {
                            Val = GetBorderValues(tableProperties.BorderType),
                            Size = Convert.ToUInt32(tableProperties.BorderSize)
                        },
                        new InsideVerticalBorder()
                        {
                            Val = GetBorderValues(tableProperties.BorderType),
                            Size = Convert.ToUInt32(tableProperties.BorderSize)
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

                docTable.AppendChild(CreateTableProperties(table.TableProperties));

                TableRow rowHeader = new TableRow();

                TableCell cellHeader = new TableCell();
                cellHeader.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "7200" },
                    new HorizontalMerge() { Val = MergedCellValues.Restart }));

                WordTextProperties textProperties = new WordTextProperties() {
                    JustificationType = WordJustificationType.Center
                };
                cellHeader.Append(new Paragraph(new Run(new Text(table.Header))));
                cellHeader.GetFirstChild<Paragraph>().ParagraphProperties = CreateParagraphProperties(textProperties);
                TableCell tmpCell1 = new TableCell();
                tmpCell1.Append(new TableCellProperties(
                    new HorizontalMerge() { Val = MergedCellValues.Continue }));
                tmpCell1.Append(new Paragraph(new Run(new Text(""))));

                TableCell tmpCell2 = new TableCell();
                tmpCell2.Append(new TableCellProperties(
                    new HorizontalMerge() { Val = MergedCellValues.Continue}));
                tmpCell2.Append(new Paragraph(new Run(new Text(""))));

                rowHeader.Append(cellHeader);
                rowHeader.Append(tmpCell1);
                rowHeader.Append(tmpCell2);
                docTable.Append(rowHeader);
                
                foreach (var row in table.Rows)
                {
                    TableCell cellName = new TableCell();
                    TableCell cellPerson = new TableCell();
                    TableCell cellDate = new TableCell();
                    
                    TableRow rowData = new TableRow();
                    
                    cellName.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellName.Append(new Paragraph(new Run(new Text(row.WarehouseName))));
                    cellPerson.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellPerson.Append(new Paragraph(new Run(new Text(row.ResponsiblePerson))));
                    cellDate.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellDate.Append(new Paragraph(new Run(new Text(row.DateCreate.ToString()))));
                    rowData.Append(cellName);
                    rowData.Append(cellPerson);
                    rowData.Append(cellDate);
                    
                    docTable.Append(rowData);
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
