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
    public class ConditionStorage : IConditionStorage
    {
        private readonly FileDataListSingleton source;
        public ConditionStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<ConditionViewModel> GetFullList()
        {
            return source.Conditions
            .Select(CreateModel)
           .ToList();
        }

        public List<ConditionViewModel> GetFilteredList(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Conditions
            .Where(rec => rec.ConditionName.Contains(model.ConditionName))
           .Select(CreateModel)
           .ToList();
        }

        public ConditionViewModel GetElement(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var condition = source.Conditions.FirstOrDefault(rec => rec.ConditionName == model.ConditionName || rec.Id == model.Id);
            return condition != null ? CreateModel(condition) : null;
        }

        public void Insert(ConditionBindingModel model)
        {
            int maxId = source.Conditions.Count > 0 ? source.Conditions.Max(rec => rec.Id) : 0;
            var element = new Condition { Id = maxId + 1 };
            source.Conditions.Add(CreateModel(model, element));
        }

        public void Update(ConditionBindingModel model)
        {
            var element = source.Conditions.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Условие не найдено");
            }
            CreateModel(model, element);
        }

        public void Delete(ConditionBindingModel model)
        {
            Condition element = source.Conditions.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Conditions.Remove(element);
            }
            else
            {
                throw new Exception("Условие не найдено");
            }
        }

        private static Condition CreateModel(ConditionBindingModel model, Condition condition)
        {
            condition.ConditionName = model.ConditionName;
            return condition;
        }

        private ConditionViewModel CreateModel(Condition condition)
        {
            return new ConditionViewModel
            {
                Id = condition.Id,
                ConditionName = condition.ConditionName
            };
        }
    }
}
