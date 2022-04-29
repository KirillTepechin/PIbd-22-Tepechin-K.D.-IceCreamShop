using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopWarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (Program.IsAuthorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouses"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (_configuration["Password"] != password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.IsAuthorized = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите пароль");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create(string warehouseName, string responsiblePerson)
        {
            if (string.IsNullOrEmpty(warehouseName) || string.IsNullOrEmpty(responsiblePerson))
            {
                return;
            }
            APIClient.PostRequest("api/warehouse/createupdatewarehouse", new WarehouseBindingModel
            {
               WarehouseName = warehouseName,
               ResponsiblePerson = responsiblePerson,
               DateCreate = DateTime.Now,
               WarhouseIngredients = new Dictionary<int, (string, int)>()
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Change(int warehouseId)
        {
            ViewBag.Warehouse =
            APIClient.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={warehouseId}");
            return View();
        }
        [HttpPost]
        public void Change(int warehouseId, string warehouseName, string responsiblePerson)
        {
            if (warehouseId == 0)
            {
                return;
            }
            WarehouseViewModel warehouse = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/getwarehouse?warehouseId={warehouseId}");
            APIClient.PostRequest("api/warehouse/createupdatewarehouse", new WarehouseBindingModel
            {
                Id = warehouseId,
                WarehouseName = warehouseName,
                ResponsiblePerson = responsiblePerson,
                WarhouseIngredients = warehouse.WarehouseIngredients,
                DateCreate = warehouse.DateCreate
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Delete(int warehouseId)
        {
            ViewBag.Warehouse =
            APIClient.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={warehouseId}");

            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public void DeleteConfirmed(int warehouseId)
        {
            if (warehouseId == 0)
            {
                return;
            }
            APIClient.PostRequest("api/warehouse/deletewarehouse", new WarehouseBindingModel
            {
                Id = warehouseId
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Replenish(int warehouseId)
        {
            ViewBag.Warehouse =
            APIClient.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={warehouseId}");
            ViewBag.Ingredients =
            APIClient.GetRequest<List<IngredientViewModel>>($"api/warehouse/getingredients");
            return View();
        }
        [HttpPost]
        public void Replenish(int warehouseId, int ingredientId, int count)
        {
            if (warehouseId == 0 || ingredientId == 0 || count < 0)
            {
                return;
            }
            APIClient.PostRequest("api/warehouse/replenishwarehouse", new ReplenishBindingModel
            {
                WarehouseId = warehouseId,
                IngredientId = ingredientId,
                Count = count,
            });
            Response.Redirect("Index");
        }
    }
}
