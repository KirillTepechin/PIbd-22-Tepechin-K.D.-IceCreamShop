using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement;
using IceCreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopListImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage 
    {
        private readonly DataListSingleton source;
        public IceCreamStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<IceCreamViewModel> GetFullList()
        {
            var result = new List<IceCreamViewModel>();
            foreach (var iceCream in source.IceCreams)
            {
                result.Add(CreateModel(iceCream));
            }
            return result;
        }
        public List<IceCreamViewModel> GetFilteredList(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<IceCreamViewModel>();
            foreach (var iceCream in source.IceCreams)
            {
                if (iceCream.IceCreamName.Contains(model.IceCreamName))
                {
                    result.Add(CreateModel(iceCream));
                }
            }
            return result;
        }
        public IceCreamViewModel GetElement(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var iceCream in source.IceCreams)
            {
                if (iceCream.Id == model.Id || iceCream.IceCreamName ==
                model.IceCreamName)
                {
                    return CreateModel(iceCream);
                }
            }
            return null;
        }
        public void Insert(IceCreamBindingModel model)
        {
            var tempIceCream = new IceCream
            {
                Id = 1,
                IceCreamIngredients = new
            Dictionary<int, int>()
            };
            foreach (var iceCream in source.IceCreams)
            {
                if (iceCream.Id >= tempIceCream.Id)
                {
                    tempIceCream.Id = iceCream.Id + 1;
                }
            }
            source.IceCreams.Add(CreateModel(model, tempIceCream));
        }
        public void Update(IceCreamBindingModel model)
        {
            IceCream tempIceCream = null;
            foreach (var iceCream in source.IceCreams)
            {
                if (iceCream.Id == model.Id)
                {
                    tempIceCream = iceCream;
                }
            }
            if (tempIceCream == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempIceCream);
        }
        public void Delete(IceCreamBindingModel model)
        {
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                if (source.IceCreams[i].Id == model.Id)
                {
                    source.IceCreams.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static IceCream CreateModel(IceCreamBindingModel model, IceCream
        iceCream)
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
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
        var iceCreamIngredients = new Dictionary<int, (string, int)>();
            foreach (var ii in iceCream.IceCreamIngredients)
            {
                string ingredientName = string.Empty;
                foreach (var ingredient in source.Ingredients)
                {
                    if (ii.Key == ingredient.Id)
                    {
                        ingredientName = ingredient.IngredientName;
                        break;
                    }
                }
                iceCreamIngredients.Add(ii.Key, (ingredientName, ii.Value));
            }
            return new IceCreamViewModel
            {
                Id = iceCream.Id,
                IceCreamName = iceCream.IceCreamName,
                Price = iceCream.Price,
                IceCreamIngredients = iceCreamIngredients
            };
        }
    }
}
