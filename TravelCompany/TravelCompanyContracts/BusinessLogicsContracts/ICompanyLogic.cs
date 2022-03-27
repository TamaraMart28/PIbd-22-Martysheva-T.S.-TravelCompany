using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface ICompanyLogic
    {
        List<CompanyViewModel> Read(CompanyBindingModel model);
        void CreateOrUpdate(CompanyBindingModel model);
        void Delete(CompanyBindingModel model);
        void AddCondition(CompanyBindingModel model, int conditionId, int count);
    }
}
