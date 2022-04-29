﻿using IceCreamShopContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.Enums;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class WorkModeling : IWorkProcess
    {
        private IOrderLogic _orderLogic;
        private readonly Random rnd;
        public WorkModeling()
        {
            rnd = new Random(1000);
        }
        /// <summary>
        /// Запуск работ
        /// </summary>
        public void DoWork(IImplementerLogic implementerLogic, IOrderLogic
        orderLogic)
        {
            _orderLogic = orderLogic;
            var implementers = implementerLogic.Read(null);
            ConcurrentBag<OrderViewModel> orders = new(_orderLogic.Read(new
            OrderBindingModel
            { SearchStatus = OrderStatus.Принят }));
            foreach (var implementer in implementers)
            {
                Task.Run(async () => await WorkerWorkAsync(implementer,
                orders));
            }
        }
        /// <summary>/// Иммитация работы исполнителя
        /// </summary>
        /// <param name="implementer"></param>
        /// <param name="orders"></param>
        private async Task WorkerWorkAsync(ImplementerViewModel implementer,
        ConcurrentBag<OrderViewModel> orders)
        {
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => _orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.Выполняется
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) *
                order.Count);
                _orderLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            var requireIngredients = await Task.Run(() => _orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.Требуются_материалы
            }));
            foreach (var order in requireIngredients)
            {
                // пытаемся назначить заказ на исполнителя
                _orderLogic.TakeOrderInWork(new
                ChangeStatusBindingModel
                { OrderId = order.Id, ImplementerId = implementer.Id });
                if (order.Status.Equals(Enum.GetName(typeof(OrderStatus), 4)))
                {
                    continue;
                }
                // делаем работу
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                _orderLogic.FinishOrder(new ChangeStatusBindingModel
                { 
                    OrderId = order.Id, ImplementerId = implementer.Id 
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            await Task.Run(() =>
            {
                while (!orders.IsEmpty)
                {
                    if (orders.TryTake(out OrderViewModel order))
                    {
                        // пытаемся назначить заказ на исполнителя
                        _orderLogic.TakeOrderInWork(new
                        ChangeStatusBindingModel
                        { OrderId = order.Id, ImplementerId = implementer.Id });
                        if (order.Status.Equals(Enum.GetName(typeof(OrderStatus), 4)))
                        {
                            continue;
                        }
                        // делаем работу
                        Thread.Sleep(implementer.WorkingTime *
                        rnd.Next(1, 5) * order.Count);
                        _orderLogic.FinishOrder(new ChangeStatusBindingModel
                        { OrderId = order.Id, ImplementerId = implementer.Id});
                        // отдыхаем
                        Thread.Sleep(implementer.PauseTime);
                    }
                }
            });
        }
    }
}
