﻿using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public void Delete(OrderBindingModel model)
        {
            
            using var context = new IceCreamShopDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            var order = context.Orders
            .Include(rec => rec.IceCream)
            .FirstOrDefault(rec => rec.Id == model.Id ||
            rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            return context.Orders
            .Include(rec => rec.IceCream)
            .Where(rec => rec.Id.Equals(model.Id))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Orders
            .Include(rec => rec.IceCream)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.IceCreamId = model.IceCreamId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                IceCreamId = order.IceCreamId,
                IceCreamName = order.IceCream.IceCreamName,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}