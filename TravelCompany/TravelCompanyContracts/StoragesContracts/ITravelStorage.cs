using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.StoragesContracts
{
    public interface ITravelStorage
    {
        List<TravelViewModel> GetFullList();
        List<TravelViewModel> GetFilteredList(TravelBindingModel model);
        TravelViewModel GetElement(TravelBindingModel model);
        void Insert(TravelBindingModel model);
        void Update(TravelBindingModel model);
        void Delete(TravelBindingModel model);
    }
}
