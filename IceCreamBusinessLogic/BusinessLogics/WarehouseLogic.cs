using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.Enums;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly IIngredientStorage _ingredientStorage;
        public WarehouseLogic(IWarehouseStorage warehouseStorage, IIngredientStorage ingredientStorage)
        {
            _warehouseStorage = warehouseStorage;
            _ingredientStorage = ingredientStorage;
        }
        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel { WarehouseName = model.WarehouseName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            var storage = _warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.Id });
            if (storage == null)
            {
                throw new Exception("Склад не найден");
            }
            _warehouseStorage.Delete(model);
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }
            return _warehouseStorage.GetFilteredList(model);
        }

        public void Replenish(ReplenishBindingModel model)
        {
            var warhouse = _warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.WarehouseId });
            var ingredient = _ingredientStorage.GetElement(new IngredientBindingModel { Id = model.IngredientId });
          
            if (warhouse.WarehouseIngredients.ContainsKey(ingredient.Id))
            {
                int count = warhouse.WarehouseIngredients[ingredient.Id].Item2;
                warhouse.WarehouseIngredients[ingredient.Id] = (ingredient.IngredientName, count + model.Count);
            }
            else
            {
                warhouse.WarehouseIngredients.Add(ingredient.Id, (ingredient.IngredientName, model.Count));
            }
            _warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warhouse.Id,
                WarehouseName = warhouse.WarehouseName,
                ResponsiblePerson = warhouse.ResponsiblePerson,
                DateCreate = warhouse.DateCreate,
                WarhouseIngredients = warhouse.WarehouseIngredients
            });
        }
    }
}
