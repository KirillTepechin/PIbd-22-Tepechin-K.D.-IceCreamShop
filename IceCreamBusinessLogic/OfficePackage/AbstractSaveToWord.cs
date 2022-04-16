using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            if (info.DocumentType == WordDocumentType.Text)
            {
                CreateWord(info);
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Center
                    }
                });

                string tab = ":\t";
                foreach (var iceCream in info.IceCreams)
                {
                    CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { (iceCream.IceCreamName, new WordTextProperties { Size = "24", Bold = true}),
                                                                      (tab, new WordTextProperties{ Size ="24", }),
                                                                      (iceCream.Price.ToString(), new WordTextProperties{ Size ="24", }) },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationType = WordJustificationType.Both
                        }
                    });
                }
                SaveWord(info);
            }
            else
            {
                CreateWord(info);
                
                CreateTable(new WordTable
                {
                    Header = info.Title,
                    Rows = info.Warehouses,
                    TableProperties = new WordTableProperties
                    {
                        TextSize = "24",
                        BorderSize = "6",
                        BorderType = WordBorderType.Single
                    }
                });
                
                SaveWord(info);
            }
        }
        protected abstract void CreateTable(WordTable table);
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateWord(WordInfo info);
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SaveWord(WordInfo info);

    }
}
