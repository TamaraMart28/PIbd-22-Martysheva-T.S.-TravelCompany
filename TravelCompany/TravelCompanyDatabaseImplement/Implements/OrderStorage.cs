using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new TravelCompanyDatabase();

            return context.Orders.Include(rec => rec.Travel).Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                TravelId = rec.TravelId,
                TravelName = rec.Travel.TravelName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            }).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new TravelCompanyDatabase();

            return context.Orders.Include(rec => rec.Travel).Where(rec => rec.TravelId == model.TravelId).Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                TravelId = rec.TravelId,
                TravelName = rec.Travel.TravelName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            }).ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new TravelCompanyDatabase();

            var order = context.Orders.Include(rec => rec.Travel).FirstOrDefault(rec => rec.Id == model.Id);

            return order != null ? CreateModel(order, context) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new TravelCompanyDatabase();

            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new TravelCompanyDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new TravelCompanyDatabase();
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

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.TravelId = model.TravelId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        
        private static OrderViewModel CreateModel(Order order, TravelCompanyDatabase context)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                TravelId = order.TravelId,
                TravelName = order.Travel.TravelName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
