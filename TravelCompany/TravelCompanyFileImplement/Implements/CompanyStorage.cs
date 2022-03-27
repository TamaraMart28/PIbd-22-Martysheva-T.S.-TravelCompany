using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyFileImplement.Models;

namespace TravelCompanyFileImplement.Implements
{
    public class CompanyStorage : ICompanyStorage
    {
        private readonly FileDataListSingleton source;

        public CompanyStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<CompanyViewModel> GetFullList()
        {
            return source.Companies
            .Select(CreateModel)
            .ToList();
        }

        public List<CompanyViewModel> GetFilteredList(CompanyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Companies
            .Where(rec => rec.CompanyName.Contains(model.CompanyName))
            .Select(CreateModel)
            .ToList();
        }

        public CompanyViewModel GetElement(CompanyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var company = source.Companies.FirstOrDefault(rec => rec.CompanyName == model.CompanyName || rec.Id == model.Id);
            return company != null ? CreateModel(company) : null;
        }

        public void Insert(CompanyBindingModel model)
        {
            int maxId = source.Companies.Count > 0 ? source.Companies.Max(rec => rec.Id) : 0;
            var element = new Company
            {
                Id = maxId + 1,
                CompanyConditions = new Dictionary<int, int>()
            };
            source.Companies.Add(CreateModel(model, element));
        }

        public void Update(CompanyBindingModel model)
        {
            var element = source.Companies.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Хранилище не найдено");
            }
            CreateModel(model, element);
        }

        public void Delete(CompanyBindingModel model)
        {
            Company element = source.Companies.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Companies.Remove(element);
            }
            else
            {
                throw new Exception("Хранилище не найдено");
            }
        }

        private static Company CreateModel(CompanyBindingModel model, Company company)
        {
            company.CompanyName = model.CompanyName;
            company.NameResponsible = model.NameResponsible;
            company.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in company.CompanyConditions.Keys.ToList())
            {
                if (!model.CompanyConditions.ContainsKey(key))
                {
                    company.CompanyConditions.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var condition in model.CompanyConditions)
            {
                if (company.CompanyConditions.ContainsKey(condition.Key))
                {
                    company.CompanyConditions[condition.Key] =
                   model.CompanyConditions[condition.Key].Item2;
                }
                else
                {
                    company.CompanyConditions.Add(condition.Key,
                   model.CompanyConditions[condition.Key].Item2);
                }
            }
            return company;
        }

        private CompanyViewModel CreateModel(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                NameResponsible = company.NameResponsible,
                DateCreate = company.DateCreate,
                CompanyConditions = company.CompanyConditions.ToDictionary(recCC => recCC.Key, recCC =>
                (source.Conditions.FirstOrDefault(recC => recC.Id == recCC.Key)?.ConditionName, recCC.Value))
            };
        }

        public bool CheckAndTake(Dictionary<int, (string, int)> conditions, int countNeed)
        {
            foreach (var cond in conditions)
            {
                int count = source.Companies.Where(rec => rec.CompanyConditions.ContainsKey(cond.Key)).Sum(rec => rec.CompanyConditions[cond.Key]);
                if (count < cond.Value.Item2 * countNeed)
                {
                    return false;
                }
            }

            foreach (var cond in conditions)
            {
                int count = cond.Value.Item2 * countNeed;
                var company = source.Companies.Where(rec => rec.CompanyConditions.ContainsKey(cond.Key));

                foreach (var comp in company)
                {
                    if (comp.CompanyConditions[cond.Key] <= count)
                    {
                        count -= comp.CompanyConditions[cond.Key];
                        comp.CompanyConditions.Remove(cond.Key);
                    }
                    else
                    {
                        comp.CompanyConditions[cond.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }
    }
}
