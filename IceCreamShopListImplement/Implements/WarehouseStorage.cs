using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.Enums;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;


namespace IceCreamShopListImplement.Implements
{
    public class WarehouseStorage: IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetFullList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                result.Add(CreateModel(warehouse));
            }
            return result;
        }
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id || warehouse.WarehouseName == model.WarehouseName)
                {
                    return CreateModel(warehouse);
                }
            }
            return null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = new Warehouse { Id = 1, WarehouseIngredients = new Dictionary<int, int>() };
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }
        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }
            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWarehouse);
        }
        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; i++)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;
            warehouse.DateCreate = model.DateCreate;
            
            foreach (var key in warehouse.WarehouseIngredients.Keys.ToList())
            {
                if (!model.WarhouseIngredients.ContainsKey(key))
                {
                    warehouse.WarehouseIngredients.Remove(key);
                }
            }
            
            foreach (var ingr in model.WarhouseIngredients)
            {
                if (warehouse.WarehouseIngredients.ContainsKey(ingr.Key))
                {
                    warehouse.WarehouseIngredients[ingr.Key] =
                    model.WarhouseIngredients[ingr.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseIngredients.Add(ingr.Key,
                    model.WarhouseIngredients[ingr.Key].Item2);
                }
            }
            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            Dictionary<int, (string, int)> warhouseIngredients = new Dictionary<int, (string, int)>();
            foreach (var wi in warehouse.WarehouseIngredients)
            {
                string ingredientName = string.Empty;
                foreach (var ingr in source.Ingredients)
                {
                    if (wi.Key == ingr.Id)
                    {
                        ingredientName = ingr.IngredientName;
                        break;
                    }
                }
                warhouseIngredients.Add(wi.Key, (ingredientName, wi.Value));
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseIngredients = warhouseIngredients
            };
        }
    }
}
