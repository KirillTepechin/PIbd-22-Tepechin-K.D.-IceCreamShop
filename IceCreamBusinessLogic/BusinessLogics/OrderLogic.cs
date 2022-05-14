using IceCreamShopBusinessLogic.MailWorker;
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
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientStorage _clientStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        public OrderLogic(IOrderStorage orderStorage, IClientStorage clientStorage,
                          IWarehouseStorage warehouseStorage, AbstractMailWorker mailWorker)
        {
            _orderStorage = orderStorage;
            _mailWorker= mailWorker;
            _clientStorage = clientStorage;
            _warehouseStorage = warehouseStorage;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                IceCreamId = model.IceCreamId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Email,
                Subject = "Заказ создан",
                Text = $"Дата: {DateTime.Now}, сумма: {model.Sum}"
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals(Enum.GetName(typeof(OrderStatus), 2)))
            {
                throw new Exception("Заказ не готов");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                IceCreamId = order.IceCreamId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан,
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ выдан",
                Text = $"Заказ №{order.Id} выдан, Дата: {DateTime.Now}"
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
           model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals(Enum.GetName(typeof(OrderStatus), 1)))
            {
                throw new Exception("Заказ не выполняется");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                IceCreamId = order.IceCreamId,
                ImplementerId = order.ImplementerId,
                ClientId = order.ClientId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ готов!",
                Text = $"Заказ №{order.Id} готов, Дата: {DateTime.Now}"
            });
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId,
            });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals(Enum.GetName(typeof(OrderStatus), 0)) && !order.Status.Equals(Enum.GetName(typeof(OrderStatus), 4)))
            {
                throw new Exception("Заказ не принят");
            }
            if (!_warehouseStorage.CheckWriteOff(new CheckWriteOffBindingModel
            {
                IceCreamId = order.IceCreamId,
                Count = order.Count
            }
            ))
            {
                order.Status = Enum.GetName(OrderStatus.Требуются_материалы);
            }
            else order.Status = Enum.GetName(OrderStatus.Выполняется);
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                IceCreamId = order.IceCreamId,
                ImplementerId = model.ImplementerId,
                ClientId = order.ClientId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = Enum.Parse<OrderStatus>(order.Status)
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ выполняется",
                Text = $"Заказ №{order.Id} выполняется, Дата: {DateTime.Now}"
            });
        }
    }
}
