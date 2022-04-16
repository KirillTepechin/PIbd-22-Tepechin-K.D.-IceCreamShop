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
            ViewBag.Warehouses =
            APIClient.GetRequest<List<WarehouseViewModel>>("api/warehouse/getwarehouses");
            return View();
        }
        [HttpPost]
        public void Create(string warehouseName, string responsiblePerson)
        {
            if (String.IsNullOrEmpty(warehouseName) || String.IsNullOrEmpty(responsiblePerson))
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
        public IActionResult Update()
        {
            ViewBag.Warehouses =
            APIClient.GetRequest<List<WarehouseViewModel>>("api/warehouse/getwarehouses");
            return View();
        }
        [HttpPost]
        public void Update(int id, string warehouseName, string responsiblePerson)
        {
            if (id == 0)
            {
                return;
            }
            APIClient.PostRequest("api/warehouse/createupdatewarehouse", new WarehouseBindingModel
            {
                Id = id,
                //TODO: Отсюда начать
            });
            Response.Redirect("Index");
        }
    }
}
