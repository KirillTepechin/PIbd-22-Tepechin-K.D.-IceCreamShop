using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.Enums;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;

        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id || order.IceCreamId == model.IceCreamId)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate == model.DateCreate) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && order.ClientId == model.ClientId) || (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status) ||
                    (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == order.Status))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }

        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order
            {
                Id = 1
            };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }
        private OrderViewModel CreateModel(Order order)
        {
            string iceCreamName = null;
            for (int i = 0; i < source.IceCreams.Count; i++)
            {
                if (source.IceCreams[i].Id == order.IceCreamId)
                {
                    iceCreamName = source.IceCreams[i].IceCreamName;
                    break;
                }
            }
            string clientFIO = null;
            for (int i = 0; i < source.Clients.Count; i++)
            {
                if (source.Clients[i].Id == order.ClientId)
                {
                    clientFIO = source.Clients[i].ClientFIO;
                    break;
                }
            }
            string implementerFIO = null;
            for (int i = 0; i < source.Implementers.Count; i++)
            {
                if (source.Implementers[i].Id == order.ImplementerId)
                {
                    implementerFIO = source.Implementers[i].ImplementerFIO;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = (int)order.Id,
                IceCreamId = order.IceCreamId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                IceCreamName = iceCreamName,
                ClientFIO = clientFIO,
                ImplementerFIO = implementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.IceCreamId = model.IceCreamId;
            order.ClientId = (int)model.ClientId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
