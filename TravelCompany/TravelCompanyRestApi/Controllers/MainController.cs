using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TravelCompanyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ITravelLogic _travel;
        public MainController(IOrderLogic order, ITravelLogic travel)
        {
            _order = order;
            _travel = travel;
        }

        [HttpGet]
        public List<TravelViewModel> GetTravelList() => _travel.Read(null)?.ToList();

        [HttpGet]
        public TravelViewModel GetTravel(int travelId) => _travel.Read(new TravelBindingModel { Id = travelId })?[0];
        
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
