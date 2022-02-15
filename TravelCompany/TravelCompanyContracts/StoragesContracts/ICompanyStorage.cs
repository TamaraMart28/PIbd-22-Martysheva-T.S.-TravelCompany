using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.StoragesContracts
{
    public interface ICompanyStorage
    {
        List<CompanyViewModel> GetFullList();
        List<CompanyViewModel> GetFilteredList(CompanyBindingModel model);
        CompanyViewModel GetElement(CompanyBindingModel model);
        void Insert(CompanyBindingModel model);
        void Update(CompanyBindingModel model);
        void Delete(CompanyBindingModel model);
    }
}
