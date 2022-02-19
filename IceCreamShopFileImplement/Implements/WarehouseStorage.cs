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
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses.Where(rec => rec.WarehouseName.Contains(model.WarehouseName)).Select(CreateModel).ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;

            var element = new Warehouse { Id = maxId + 1, WarehouseIngredients = new Dictionary<int, int>() };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        
        public bool CheckWriteOff(CheckWriteOffBindingModel model)
        {
            var list = GetFullList();
            var neccesary = new Dictionary<int, int>(source.IceCreams.FirstOrDefault(rec => rec.Id == model.IceCreamId).IceCreamIngredients);
            var available = new Dictionary<int, int>();
            neccesary.ToDictionary(kvp => neccesary[kvp.Key] *= model.Count);
            foreach (var warehouse in list)
            {
                foreach(var ingr in warehouse.WarehouseIngredients)
                {
                    if (available.ContainsKey(ingr.Key))
                    {
                        available[ingr.Key] += ingr.Value.Item2;
                    }
                    else
                    {
                        available.Add(ingr.Key, ingr.Value.Item2);
                    }
                }
            }

            bool can = available.ToList().All(ingr => ingr.Value >= neccesary[ingr.Key]);
            if (!can || available.Count==0)
            {
                return false;
            }

            foreach (var warehouse in list)
            {
                var warehouseIngredients = warehouse.WarehouseIngredients;
                foreach (var key in warehouse.WarehouseIngredients.Keys)
                {
                    var value = warehouse.WarehouseIngredients[key];
                    if (neccesary.ContainsKey(key))
                    {
                        if (value.Item2 > neccesary[key])
                        {
                            warehouseIngredients[key] = (value.Item1, value.Item2 - neccesary[key]);
                            neccesary[key] = 0;
                        }
                        else
                        {
                            warehouseIngredients[key] = (value.Item1, 0);
                            neccesary[key] -= value.Item2;
                        }
                        Update(new WarehouseBindingModel
                        {
                            Id = warehouse.Id,
                            WarehouseName = warehouse.WarehouseName,
                            ResponsiblePerson = warehouse.ResponsiblePerson,
                            DateCreate = warehouse.DateCreate,
                            WarhouseIngredients = warehouseIngredients
                        });
                    }
                }
            }
            return true;
        }
        
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;
            warehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in warehouse.WarehouseIngredients.Keys.ToList())
            {
                if (!model.WarhouseIngredients.ContainsKey(key))
                {
                    warehouse.WarehouseIngredients.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarhouseIngredients)
            {
                if (warehouse.WarehouseIngredients.ContainsKey(component.Key))
                {
                    warehouse.WarehouseIngredients[component.Key] = model.WarhouseIngredients[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseIngredients.Add(component.Key, model.WarhouseIngredients[component.Key].Item2);
                }
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseIngredients = warehouse.WarehouseIngredients.ToDictionary(recWI => recWI.Key, recWI =>
(source.Ingredients.FirstOrDefault(recI => recI.Id == recWI.Key)?.IngredientName, recWI.Value))
            };
        }
    }
}
