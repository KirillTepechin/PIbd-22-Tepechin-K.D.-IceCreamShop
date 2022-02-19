using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopFileImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage
    {
        private readonly FileDataListSingleton source;
        public IceCreamStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(IceCreamBindingModel model)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.IceCreams.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public IceCreamViewModel GetElement(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var iceCream = source.IceCreams
                .FirstOrDefault(rec => rec.IceCreamName == model.IceCreamName || rec.Id == model.Id);
            return iceCream != null ? CreateModel(iceCream) : null;      
        }

        public List<IceCreamViewModel> GetFilteredList(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.IceCreams
                .Where(rec => rec.IceCreamName.Contains(model.IceCreamName))
                .Select(CreateModel)
                .ToList();
        }

        public List<IceCreamViewModel> GetFullList()
        {
            return source.IceCreams
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(IceCreamBindingModel model)
        {
            int maxId = source.IceCreams.Count > 0 ? source.IceCreams.Max(rec => rec.Id) : 0;
            var element = new IceCream
            {
                Id = maxId + 1,
                IceCreamIngredients = new Dictionary<int, int>()
            };
            source.IceCreams.Add(CreateModel(model, element));
        }

        public void Update(IceCreamBindingModel model)
        {
            var element = source.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        private static IceCream CreateModel(IceCreamBindingModel model, IceCream iceCream)
        {
            iceCream.IceCreamName = model.IceCreamName;
            iceCream.Price = model.Price;
            // удаляем убранные
            foreach (var key in iceCream.IceCreamIngredients.Keys.ToList())
            {
                if (!model.IceCreamIngredients.ContainsKey(key))
                {
                    iceCream.IceCreamIngredients.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var ingredient in model.IceCreamIngredients)
            {
                if (iceCream.IceCreamIngredients.ContainsKey(ingredient.Key))
                {
                    iceCream.IceCreamIngredients[ingredient.Key] =
                   model.IceCreamIngredients[ingredient.Key].Item2;
                }
                else
                {
                    iceCream.IceCreamIngredients.Add(ingredient.Key,
                   model.IceCreamIngredients[ingredient.Key].Item2);
                }
            }
            return iceCream;
        }
        private IceCreamViewModel CreateModel(IceCream iceCream)
        {
            return new IceCreamViewModel
            {
                Id = iceCream.Id,
                IceCreamName = iceCream.IceCreamName,
                Price = iceCream.Price,
                IceCreamIngredients = iceCream.IceCreamIngredients
                    .ToDictionary(recPC => recPC.Key, recPC => (source.Ingredients
                    .FirstOrDefault(recC => recC.Id == recPC.Key) ?.IngredientName, recPC.Value))
            };

        }
    }
}
