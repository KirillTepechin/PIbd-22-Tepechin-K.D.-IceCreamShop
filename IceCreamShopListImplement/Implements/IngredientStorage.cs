using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopListImplement.Implements
{
    public class IngredientStorage : IIngredientStorage
    {
        private readonly DataListSingleton source;
        public IngredientStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<IngredientViewModel> GetFullList()
        {
            var result = new List<IngredientViewModel>();
            foreach (var ingredient in source.Ingredients)
            {
                result.Add(CreateModel(ingredient));
            }
            return result;
        }
        public List<IngredientViewModel> GetFilteredList(IngredientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<IngredientViewModel>();
            foreach (var ingredient in source.Ingredients)
            {
                if (ingredient.IngredientName.Contains(model.IngredientName))
                {
                    result.Add(CreateModel(ingredient));
                }
            }
            return result;
        }
        public IngredientViewModel GetElement(IngredientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var ingredient in source.Ingredients)
            {
                if (ingredient.Id == model.Id || ingredient.IngredientName ==
               model.IngredientName)
                {
                    return CreateModel(ingredient);
                }
            }
            return null;
        }
        public void Insert(IngredientBindingModel model)
        {
            var tempIngredient = new Ingredient { Id = 1 };
            foreach (var ingredient in source.Ingredients)
            {
                if (ingredient.Id >= tempIngredient.Id)
                {
                    tempIngredient.Id = ingredient.Id + 1;
                }
            }
            source.Ingredients.Add(CreateModel(model, tempIngredient));
        }
        public void Update(IngredientBindingModel model)
        {
            Ingredient tempIngredient = null;
            foreach (var ingredient in source.Ingredients)
            {
                if (ingredient.Id == model.Id)
                {
                    tempIngredient = ingredient;
                }
            }
            if (tempIngredient == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempIngredient);
        }
        public void Delete(IngredientBindingModel model)
        {
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                if (source.Ingredients[i].Id == model.Id.Value)
                {
                    source.Ingredients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Ingredient CreateModel(IngredientBindingModel model, Ingredient ingredient)
        {
            ingredient.IngredientName = model.IngredientName;
            return ingredient;
        }
        private static IngredientViewModel CreateModel(Ingredient ingredient)
        {
            return new IngredientViewModel
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName
            };
        }
    }
}
