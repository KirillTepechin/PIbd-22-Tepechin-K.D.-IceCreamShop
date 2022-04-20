using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseLogic _warehouseLogic;
        private readonly IIngredientLogic _ingredientLogic;
        public WarehouseController(IWarehouseLogic warehouseLogic, IIngredientLogic ingredientLogic)
        {
            _warehouseLogic = warehouseLogic;
            _ingredientLogic = ingredientLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetWarehouses() => _warehouseLogic.Read(null)?.ToList();
        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => _warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];
        [HttpGet]
        public List<IngredientViewModel> GetIngredients() => _ingredientLogic.Read(null)?.ToList();
        [HttpPost]
        public void CreateUpdateWarehouse(WarehouseBindingModel model) => _warehouseLogic.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouseLogic.Delete(model);
        [HttpPost]
        public void ReplenishWarehouse(ReplenishBindingModel model) => _warehouseLogic.Replenish(model);
    }
}
