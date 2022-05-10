﻿using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TravelCompanyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _messageLogic;
        private readonly int _messagesOnPage = 3;
        public ClientController(IClientLogic logic, IMessageInfoLogic messageLogic)
        {
            _logic = logic;
            _messageLogic = messageLogic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClientBindingModel
            {
                Login = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetClientsMessages(int clientId, int page)
        {
            var list = _messageLogic.Read(new MessageInfoBindingModel
            {
                ClientId = clientId,
                ToSkip = (page - 1) * _messagesOnPage,
                ToTake = _messagesOnPage + 1
            }).ToList();
            var isNext = !(list.Count() <= _messagesOnPage);
            return (list.Take(_messagesOnPage).ToList(), isNext);
        }
        
        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
