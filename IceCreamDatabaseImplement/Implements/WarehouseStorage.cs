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

namespace IceCreamShopDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public bool CheckWriteOff(CheckWriteOffBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var neccesary = context.IceCreamIngredients.Where(rec => rec.IceCreamId == model.IceCreamId)
                                                       .ToDictionary(rec => rec.IngredientId, rec => rec.Count * model.Count);
            using var transaction = context.Database.BeginTransaction();
            foreach (var key in neccesary.Keys)
            {
                foreach (var wi in context.WarehouseIngredients.Where(rec => rec.IngredientId == key))
                {
                    if (wi.Count > neccesary[key])
                    {
                        wi.Count -= neccesary[key];
                        neccesary[key] = 0;
                        break;
                    }
                    else
                    {
                        neccesary[key] -= wi.Count;
                        wi.Count = 0;
                    }
                }
                if (neccesary[key] > 0)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            context.SaveChanges();
            transaction.Commit();
            return true;
        }

        public void Delete(WarehouseBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Warehouses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            var warehouse = context.Warehouses
            .Include(rec => rec.WarehouseIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
            rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            return context.Warehouses
            .Include(rec => rec.WarehouseIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Warehouses
            .Include(rec => rec.WarehouseIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(WarehouseBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Warehouse warehouse = new Warehouse()
                {
                    WarehouseName = model.WarehouseName,
                    ResponsiblePerson = model.ResponsiblePerson,
                    DateCreate = model.DateCreate
                };
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
                CreateModel(model, warehouse, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Warehouses.FirstOrDefault(rec => rec.Id ==
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
        private static WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseIngredients = warehouse.WarehouseIngredients
            .ToDictionary(recII => recII.IngredientId,
            recII => (recII.Ingredient?.IngredientName, recII.Count))
            };
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse,
        IceCreamShopDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;
            warehouse.DateCreate = model.DateCreate;
            if (model.Id.HasValue)
            {
                var warehouseIngredients = context.WarehouseIngredients.Where(rec =>
                rec.WarehouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.WarehouseIngredients.RemoveRange(warehouseIngredients.Where(rec =>
                !model.WarhouseIngredients.ContainsKey(rec.IngredientId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateIngredient in warehouseIngredients)
                {
                    updateIngredient.Count =
                    model.WarhouseIngredients[updateIngredient.IngredientId].Item2;
                    model.WarhouseIngredients.Remove(updateIngredient.IngredientId);
                }
                context.SaveChanges();
            }
            foreach (var wi in model.WarhouseIngredients)
            {
                context.WarehouseIngredients.Add(new WarehouseIngredient
                {
                    WarehouseId = warehouse.Id,
                    IngredientId = wi.Key,
                    Count = wi.Value.Item2,
                });
                context.SaveChanges();
            }
            return warehouse;
        }
    }
}
