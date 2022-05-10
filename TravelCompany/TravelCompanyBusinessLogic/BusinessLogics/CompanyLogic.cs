using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogics
{
    public class CompanyLogic : ICompanyLogic
    {
        private readonly ICompanyStorage _companyStorage;
        private readonly IConditionStorage _conditionStorage;

        public CompanyLogic(ICompanyStorage companyStorage, IConditionStorage conditionStorage)
        {
            _companyStorage = companyStorage;
            _conditionStorage = conditionStorage;
        }

        public List<CompanyViewModel> Read(CompanyBindingModel model)
        {
            if (model == null)
            {
                return _companyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CompanyViewModel> { _companyStorage.GetElement(model) };
            }
            return _companyStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CompanyBindingModel model)
        {
            var element = _companyStorage.GetElement(new CompanyBindingModel { CompanyName = model.CompanyName });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть хранилище с таким названием");
            }
            if (model.Id.HasValue)
            {
                _companyStorage.Update(model);
            }
            else
            {
                _companyStorage.Insert(model);
            }
        }

        public void Delete(CompanyBindingModel model)
        {
            var element = _companyStorage.GetElement(new CompanyBindingModel { Id = model.Id });
            
            if (element == null)
            {
                throw new Exception("Хранилище не найдено");
            }
            _companyStorage.Delete(model);
        }

        public void AddCondition(CompanyBindingModel model, int conditionId, int count)
        {
            var company = _companyStorage.GetElement(new CompanyBindingModel { Id = model.Id });
            if (company == null)
            {
                throw new Exception("Хранилище не найдено");
            }

            var condition = _conditionStorage.GetElement(new ConditionBindingModel { Id = conditionId });
            if (condition == null)
            {
                throw new Exception("Условие не найдено");
            }

            if (company.CompanyConditions.ContainsKey(conditionId))
            {
                int countBefore = company.CompanyConditions[conditionId].Item2;
                company.CompanyConditions[conditionId] = (condition.ConditionName, countBefore + count);
            }
            else
            {
                company.CompanyConditions.Add(conditionId, (condition.ConditionName, count));
            }

            _companyStorage.Update(new CompanyBindingModel
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                NameResponsible = company.NameResponsible,
                DateCreate = company.DateCreate,
                CompanyConditions = company.CompanyConditions
            });
        }
    }
}
