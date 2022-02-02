using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.StoragesContracts
{
    public interface IConditionStorage
    {
        List<ConditionViewModel> GetFullList();
        List<ConditionViewModel> GetFilteredList(ConditionBindingModel model);
        ConditionViewModel GetElement(ConditionBindingModel model);
        void Insert(ConditionBindingModel model);
        void Update(ConditionBindingModel model);
        void Delete(ConditionBindingModel model);
    }
}
