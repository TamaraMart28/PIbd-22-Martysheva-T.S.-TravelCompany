﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;


namespace TravelCompanyContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        MessageInfoViewModel GetElement(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
        void Update(MessageInfoBindingModel model);
    }
}
