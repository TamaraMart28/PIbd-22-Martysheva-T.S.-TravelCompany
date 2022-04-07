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
    public class CompanyStorage : ICompanyStorage
    {
        private readonly DataListSingleton source;

        public CompanyStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CompanyViewModel> GetFullList()
        {
            var result = new List<CompanyViewModel>();
            foreach (var company in source.Companies)
            {
                result.Add(CreateModel(company));
            }
            return result;
        }

        public List<CompanyViewModel> GetFilteredList(CompanyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<CompanyViewModel>();
            foreach (var company in source.Companies)
            {
                if (company.CompanyName.Contains(model.CompanyName))
                {
                    result.Add(CreateModel(company));
                }
            }
            return result;
        }

        public CompanyViewModel GetElement(CompanyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var company in source.Companies)
            {
                if (company.Id == model.Id || company.CompanyName == model.CompanyName)
                {
                    return CreateModel(company);
                }
            }
            return null;
        }

        public void Insert(CompanyBindingModel model)
        {
            var tempCompany = new Company
            {
                Id = 1,
                CompanyConditions = new Dictionary<int, int>()
            };
            foreach (var company in source.Companies)
            {
                if (company.Id >= tempCompany.Id)
                {
                    tempCompany.Id = company.Id + 1;
                }
            }
            source.Companies.Add(CreateModel(model, tempCompany));
        }

        public void Update(CompanyBindingModel model)
        {
            Company tempCompany = null;
            foreach (var company in source.Companies)
            {
                if (company.Id == model.Id)
                {
                    tempCompany = company;
                }
            }
            if (tempCompany == null)
            {
                throw new Exception("Хранилище не найдено");
            }
            CreateModel(model, tempCompany);
        }

        public void Delete(CompanyBindingModel model)
        {
            for (int i = 0; i < source.Companies.Count; ++i)
            {
                if (source.Companies[i].Id == model.Id)
                {
                    source.Companies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Хранилище не найдено");
        }

        private static Company CreateModel(CompanyBindingModel model, Company company)
        {
            company.CompanyName = model.CompanyName;
            company.NameResponsible = model.NameResponsible;
            company.DateCreate = model.DateCreate;
            
            foreach (var key in company.CompanyConditions.Keys.ToList())
            {
                if (!model.CompanyConditions.ContainsKey(key))
                {
                    company.CompanyConditions.Remove(key);
                }
            }
            
            foreach (var condition in model.CompanyConditions)
            {
                if (company.CompanyConditions.ContainsKey(condition.Key))
                {
                    company.CompanyConditions[condition.Key] = model.CompanyConditions[condition.Key].Item2;
                }
                else
                {
                    company.CompanyConditions.Add(condition.Key, model.CompanyConditions[condition.Key].Item2);
                }
            }
            return company;
        }

        private CompanyViewModel CreateModel(Company company)
        {
            var companyConditions = new Dictionary<int, (string, int)>();
            foreach (var cc in company.CompanyConditions)
            {
                string conditionName = string.Empty;
                foreach (var condition in source.Conditions)
                {
                    if (cc.Key == condition.Id)
                    {
                        conditionName = condition.ConditionName;
                        break;
                    }
                }
                companyConditions.Add(cc.Key, (conditionName, cc.Value));
            }
            return new CompanyViewModel
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                NameResponsible = company.NameResponsible,
                DateCreate = company.DateCreate,
                CompanyConditions = companyConditions
            };
        }

        public bool CheckAndTake(Dictionary<int, (string, int)> conditions, int countNeed)
        {
            throw new NotImplementedException();
        }
    }
}
