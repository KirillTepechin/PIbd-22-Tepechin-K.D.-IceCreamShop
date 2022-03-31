using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IIceCreamLogic _iceCream;
        public MainController(IOrderLogic order, IIceCreamLogic iceCream)
        {
            _order = order;
            _iceCream = iceCream;
        }
        [HttpGet]
        public List<IceCreamViewModel> GetIceCreamList() => _iceCream.Read(null)?.ToList();
        [HttpGet]
        public IceCreamViewModel GetIceCream(int iceCreamId) => _iceCream.Read(new 
       IceCreamBindingModel
        { Id = iceCreamId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}