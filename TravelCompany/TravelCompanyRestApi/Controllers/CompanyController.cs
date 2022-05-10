using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyLogic _company;
        private readonly IConditionLogic _condition;

        public CompanyController(ICompanyLogic company, IConditionLogic condition)
        {
            _company = company;
            _condition = condition;
        }

        [HttpGet]
        public List<CompanyViewModel> GetCompanyList() => _company.Read(null)?.ToList();

        [HttpGet]
        public CompanyViewModel GetCompany(int companyId) => _company.Read(new CompanyBindingModel { Id = companyId })?[0];

        [HttpGet]
        public List<ConditionViewModel> GetConditionsList() => _condition.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateCompany(CompanyBindingModel model) => _company.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteCompany(CompanyBindingModel model) => _company.Delete(model);

        [HttpPost]
        public void AddConditionToCompany(AddConditionBindingModel model) =>
            _company.AddCondition(new CompanyBindingModel { Id = model.Id }, model.ConditionId, model.Count);
    }
}
