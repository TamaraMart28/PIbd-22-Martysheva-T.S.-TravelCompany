using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyListImplement.Models;

namespace TravelCompanyListImplement.Implements
{
    public class MessageInfoStorage /*: IMessageInfoStorage*/
    {
        private readonly DataListSingleton source;
        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

    }
}
