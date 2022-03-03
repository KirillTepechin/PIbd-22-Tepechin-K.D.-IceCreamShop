using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDatabaseImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage
    {
        public void Delete(IceCreamBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            IceCream element = context.IceCreams.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.IceCreams.Remove(element);
                context.SaveChanges();
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
            using var context = new IceCreamShopDatabase();
            var product = context.IceCreams
            .Include(rec => rec.IceCreamIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .FirstOrDefault(rec => rec.IceCreamName == model.IceCreamName ||
            rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public List<IceCreamViewModel> GetFilteredList(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            return context.IceCreams
            .Include(rec => rec.IceCreamIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .Where(rec => rec.IceCreamName.Contains(model.IceCreamName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<IceCreamViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.IceCreams
            .Include(rec => rec.IceCreamIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .ToList()
            .Select(CreateModel)
            .ToList();

        }

        public void Insert(IceCreamBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                IceCream iceCream = new IceCream()
                {
                    IceCreamName = model.IceCreamName,
                    Price = model.Price

                };
                context.IceCreams.Add(iceCream);
                context.SaveChanges();
                CreateModel(model, iceCream, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(IceCreamBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.IceCreams.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }
        private static IceCream CreateModel(IceCreamBindingModel model, IceCream iceCream, IceCreamShopDatabase context)
        {
            iceCream.IceCreamName = model.IceCreamName;
            iceCream.Price = model.Price;
            if (model.Id.HasValue)
            {
                var iceCreamIngredients = context.IceCreamIngredients.Where(rec =>
               rec.IceCreamId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.IceCreamIngredients.RemoveRange(iceCreamIngredients.Where(rec =>
               !model.IceCreamIngredients.ContainsKey(rec.IngredientId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in iceCreamIngredients)
                {
                    updateComponent.Count =
                   model.IceCreamIngredients[updateComponent.IngredientId].Item2;
                    model.IceCreamIngredients.Remove(updateComponent.IngredientId);
                }
                context.SaveChanges();
            }
            foreach(var ii in model.IceCreamIngredients)
            {
                context.IceCreamIngredients.Add(new IceCreamIngredient
                {
                    IceCreamId = iceCream.Id,
                    IngredientId = ii.Key,
                    Count = ii.Value.Item2
                });
                context.SaveChanges();
            }
            return iceCream;
        }
        private static IceCreamViewModel CreateModel(IceCream iceCream)
        {
            return new IceCreamViewModel
            {
                Id = iceCream.Id,
                IceCreamName = iceCream.IceCreamName,
                Price = iceCream.Price,
                IceCreamIngredients = iceCream.IceCreamIngredients
            .ToDictionary(recII => recII.IngredientId,
            recII => (recII.Ingredient?.IngredientName, recII.Count))
            };
        }
    }
}

