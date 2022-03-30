using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IIceCreamLogic _iceCream;
        public MainController(IOrderLogic order, IIceCreamLogic product)
        {
            _order = order;
            _iceCream = product;
        }
        [HttpGet]
        public List<IceCreamViewModel> GetIceCreamList() => _iceCream.Read(null)?.ToList();
        [HttpGet]
        public IceCreamViewModel GetIceCream(int productId) => _iceCream.Read(new
       IceCreamBindingModel
        { Id = productId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}