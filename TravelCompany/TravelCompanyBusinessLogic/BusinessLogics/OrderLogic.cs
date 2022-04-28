using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyContracts.Enums;

namespace TravelCompanyBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly ITravelStorage _travelStorage;
        private readonly ICompanyStorage _companyStorage;
        private readonly object locker = new object();

        public OrderLogic(IOrderStorage orderStorage, ITravelStorage travelStorage, ICompanyStorage companyStorage)
        {
            _orderStorage = orderStorage;
            _travelStorage = travelStorage;
            _companyStorage = companyStorage;
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

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                TravelId = model.TravelId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят,
                DateCreate = DateTime.Now            
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                if (order.Status != Enum.GetName(typeof(OrderStatus), 0) && order.Status != Enum.GetName(typeof(OrderStatus), 4))
                {
                    throw new Exception("Заказ не в статусе \"Принят\" или \"Требуются материалы\"");
                }
                var travel = _travelStorage.GetElement(new TravelBindingModel { Id = order.TravelId });
                var tempOrder = new OrderBindingModel
                {
                    Id = order.Id,
                    TravelId = order.TravelId,
                    ClientId = order.ClientId,
                    ImplementerId = model.ImplementerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate
                };
                if (_companyStorage.CheckAndTake(travel.TravelConditions, tempOrder.Count))
                {
                    tempOrder.Status = OrderStatus.Выполняется;
                    tempOrder.DateImplement = DateTime.Now;
                    _orderStorage.Update(tempOrder);
                }
                else
                {
                    tempOrder.Status = OrderStatus.ТребуютсяМатериалы;
                    _orderStorage.Update(tempOrder);
                }
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status == Enum.GetName(typeof(OrderStatus), 4))
            {
                return;
            }
            if (order.Status != Enum.GetName(typeof(OrderStatus), 1))
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                TravelId = order.TravelId,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model) 
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status != Enum.GetName(typeof(OrderStatus), 2))
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                TravelId = order.TravelId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан
            });
        }
    }
}
