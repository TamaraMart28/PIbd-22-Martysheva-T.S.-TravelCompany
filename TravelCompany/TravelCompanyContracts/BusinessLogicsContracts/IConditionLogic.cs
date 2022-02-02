using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;


namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IConditionLogic
    {
        List<ConditionViewModel> Read(ConditionBindingModel model);
        void CreateOrUpdate(ConditionBindingModel model);
        void Delete(ConditionBindingModel model);
    }
}
