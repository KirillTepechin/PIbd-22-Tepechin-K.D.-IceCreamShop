using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Implements
{
    public class IngredientStorage : IIngredientStorage
    {
        private readonly FileDataListSingleton source;
        public IngredientStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(IngredientBindingModel model)
        {
            Ingredient element = source.Ingredients.FirstOrDefault(rec => rec.Id ==
model.Id);
            if (element != null)
            {
                source.Ingredients.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public IngredientViewModel GetElement(IngredientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var component = source.Ingredients
            .FirstOrDefault(rec => rec.IngredientName == model.IngredientName ||
           rec.Id == model.Id);
            return component != null ? CreateModel(component) : null;
        }

        public List<IngredientViewModel> GetFilteredList(IngredientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Ingredients
                .Where(rec => rec.IngredientName.Contains(model.IngredientName))
                .Select(CreateModel)
                .ToList();

        }

        public List<IngredientViewModel> GetFullList()
        {
            return source.Ingredients
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(IngredientBindingModel model)
        {
            int maxId = source.Ingredients.Count > 0 ? source.Ingredients.Max(rec => rec.Id) : 0;
            var element = new Ingredient { Id = maxId + 1 };
            source.Ingredients.Add(CreateModel(model, element));

        }

        public void Update(IngredientBindingModel model)
        {
            var element = source.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        private static Ingredient CreateModel(IngredientBindingModel model, Ingredient component)
        {
            component.IngredientName = model.IngredientName;
            return component;
        }
        private IngredientViewModel CreateModel(Ingredient component)
        {
            return new IngredientViewModel
            {
                Id = component.Id,
                IngredientName = component.IngredientName
            };
        }
    }
}
