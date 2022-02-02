using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface ITravelLogic
    {
        List<TravelViewModel> Read(TravelBindingModel model);
        void CreateOrUpdate(TravelBindingModel model);
        void Delete(TravelBindingModel model);
    }
}
